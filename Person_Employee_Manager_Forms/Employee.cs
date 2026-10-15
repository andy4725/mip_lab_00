namespace PersonEmployeeManager;

public class Employee : Person
{
    public override string Position => "Employee";
    public override decimal Salary { get; }

    public Employee(string username, string encodedPassword, string name, int age, decimal salary)
        : base(username, encodedPassword, name, age)
    {
        Salary = salary;
    }
}
