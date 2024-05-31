namespace ZeroToHero.Domain.Entities;

public class Employee
{
    public string FullName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public int Salary { get; set; }
    public DateTime WorkingTime { get; set; }

}
