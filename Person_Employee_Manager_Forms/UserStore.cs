using Microsoft.Data.Sqlite;
using System.Globalization;

namespace PersonEmployeeManager;

public class UserStore : IUserStore
{
    private readonly string connectionString;

    public UserStore()
    {
        string databasePath = Path.Combine(AppContext.BaseDirectory, "users.db");
        connectionString = new SqliteConnectionStringBuilder { DataSource = databasePath }.ToString();
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = """
            CREATE TABLE IF NOT EXISTS Users (
                Username TEXT NOT NULL COLLATE NOCASE PRIMARY KEY,
                EncodedPassword TEXT NOT NULL,
                Name TEXT NOT NULL,
                Age INTEGER NOT NULL CHECK (Age >= 0),
                Position TEXT NOT NULL CHECK (Position IN ('Employee', 'Manager')),
                Salary TEXT NOT NULL
            );
            """;
        command.ExecuteNonQuery();
    }

    public List<Person> Load()
    {
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Username, EncodedPassword, Name, Age, Position, Salary FROM Users ORDER BY Username;";
        using var reader = command.ExecuteReader();
        var people = new List<Person>();
        while (reader.Read())
        {
            Person? person = CreatePerson(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                reader.GetInt32(3), reader.GetString(4), decimal.Parse(reader.GetString(5), CultureInfo.InvariantCulture));
            if (person is not null) people.Add(person);
        }
        return people;
    }

    public Person? FindByUsername(string username)
    {
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Username, EncodedPassword, Name, Age, Position, Salary FROM Users WHERE Username = $username;";
        command.Parameters.AddWithValue("$username", username.Trim());
        using var reader = command.ExecuteReader();
        return reader.Read()
            ? CreatePerson(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3),
                reader.GetString(4), decimal.Parse(reader.GetString(5), CultureInfo.InvariantCulture))
            : null;
    }

    public bool Create(Person person)
    {
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT OR IGNORE INTO Users (Username, EncodedPassword, Name, Age, Position, Salary) VALUES ($username, $password, $name, $age, $position, $salary);";
        command.Parameters.AddWithValue("$username", person.Username.Trim());
        command.Parameters.AddWithValue("$password", person.EncodedPassword);
        command.Parameters.AddWithValue("$name", person.Name);
        command.Parameters.AddWithValue("$age", person.Age);
        command.Parameters.AddWithValue("$position", person.Position);
        command.Parameters.AddWithValue("$salary", person.Salary.ToString(CultureInfo.InvariantCulture));
        return command.ExecuteNonQuery() == 1;
    }

    public void Save(List<Person> people)
    {
        using var connection = OpenConnection();
        using var transaction = connection.BeginTransaction();
        using var command = connection.CreateCommand();
        command.Transaction = transaction;
        command.CommandText = "DELETE FROM Users;";
        command.ExecuteNonQuery();
        command.CommandText = "INSERT INTO Users (Username, EncodedPassword, Name, Age, Position, Salary) VALUES ($username, $password, $name, $age, $position, $salary);";
        foreach (Person person in people)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("$username", person.Username.Trim());
            command.Parameters.AddWithValue("$password", person.EncodedPassword);
            command.Parameters.AddWithValue("$name", person.Name);
            command.Parameters.AddWithValue("$age", person.Age);
            command.Parameters.AddWithValue("$position", person.Position);
            command.Parameters.AddWithValue("$salary", person.Salary.ToString(CultureInfo.InvariantCulture));
            command.ExecuteNonQuery();
        }
        transaction.Commit();
    }

    private SqliteConnection OpenConnection()
    {
        var connection = new SqliteConnection(connectionString);
        connection.Open();
        return connection;
    }

    private static Person? CreatePerson(string username, string password, string name, int age, string position, decimal salary) =>
        position switch
        {
            "Employee" => new Employee(username, password, name, age, salary),
            "Manager" => new Manager(username, password, name, age, salary),
            _ => null
        };
}
