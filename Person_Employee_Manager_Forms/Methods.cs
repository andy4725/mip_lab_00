using System.Globalization;

namespace PersonEmployeeManager;

internal static class Methods
{
    private static readonly IUserStore Store = new UserStore();
    private static void SignUp()
    {
        List<Person> people = Store.Load();
        Console.Write("Username: ");
        string username = (Console.ReadLine() ?? "").Trim();
        if (username.Length == 0 || people.Any(person => person.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Username is empty or already taken.");
            return;
        }

        Console.Write("Password: ");
        string password = Console.ReadLine() ?? "";
        Console.Write("Name: ");
        string name = (Console.ReadLine() ?? "").Trim();
        if (password.Length == 0 || name.Length == 0 || !ReadInt("Age: ", out int age) || age < 0 ||
            !ReadDecimal("Salary: ", out decimal salary) || salary < 0)
        {
            Console.WriteLine("Please enter a non-empty password and name, and valid non-negative numbers.");
            return;
        }

        Console.Write("Position (1 Employee, 2 Manager): ");
        string? position = Console.ReadLine();
        string encodedPassword = Person.EncodePassword(password);
        if (position == "1") people.Add(new Employee(username, encodedPassword, name, age, salary));
        else if (position == "2") people.Add(new Manager(username, encodedPassword, name, age, salary));
        else { Console.WriteLine("Unknown position."); return; }

        Store.Save(people);
        Console.WriteLine("Account created.");
    }

    private static void SignIn()
    {
        Console.Write("Username: ");
        string username = Console.ReadLine() ?? "";
        Console.Write("Password: ");
        string password = Console.ReadLine() ?? "";
        Person? person = Store.Load().FirstOrDefault(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (person is null || person.EncodedPassword != Person.EncodePassword(password))
        {
            Console.WriteLine("Username or password is incorrect.");
            return;
        }

        Console.WriteLine($"Welcome, {person.Name}!");
        ShowPerson(person);
    }

    private static void ListUsers()
    {
        List<Person> people = Store.Load();
        if (people.Count == 0) { Console.WriteLine("No users saved yet."); return; }
        foreach (Person person in people) ShowPerson(person);
    }

    private static void ShowPerson(Person person)
    {
        Console.WriteLine($"{person.Name} ({person.Position}), age {person.Age}, salary {person.Salary.ToString("0.00", CultureInfo.InvariantCulture)}");
    }

    private static void DeleteAccount()
    {
        List<Person> people = Store.Load();
        Console.Write("Username: ");
        string username = Console.ReadLine() ?? "";
        Person? person = people.FirstOrDefault(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (person is null) { Console.WriteLine("Account not found."); return; }

        Console.Write("Password to confirm: ");
        string password = Console.ReadLine() ?? "";
        if (person.EncodedPassword != Person.EncodePassword(password))
        {
            Console.WriteLine("Password is incorrect. Account was not deleted.");
            return;
        }

        people.Remove(person);
        Store.Save(people);
        Console.WriteLine("Account deleted.");
    }

    private static bool ReadInt(string prompt, out int value)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out value);
    }

    private static bool ReadDecimal(string prompt, out decimal value)
    {
        Console.Write(prompt);
        return decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out value);
    }
}
