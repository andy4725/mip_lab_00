namespace PersonEmployeeManager;

public class Manager : Employee
{
    public override string Position => "Manager";

    public Manager(string username, string encodedPassword, string name, int age, decimal salary)
        : base(username, encodedPassword, name, age, salary)
    {
    }
}
