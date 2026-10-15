namespace PersonEmployeeManager;

using System.Globalization;
using System.Security.Cryptography;

public abstract class Person
{
    public string Username { get; set; }
    public string EncodedPassword { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    protected Person(string username, string encodedPassword, string name, int age)
    {
        Username = username;
        EncodedPassword = encodedPassword;
        Name = name;
        Age = age;
    }

    public static string EncodePassword(string password)
    {
        const int iterations = 210_000;
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, 32);
        return $"pbkdf2${iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        string[] parts = storedHash.Split('$');
        if (parts.Length != 4 || parts[0] != "pbkdf2" ||
            !int.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out int iterations) || iterations < 1)
            return false;

        try
        {
            byte[] salt = Convert.FromBase64String(parts[2]);
            byte[] expectedHash = Convert.FromBase64String(parts[3]);
            byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expectedHash.Length);
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public abstract string Position { get; }
    public abstract decimal Salary { get; }
}
