using ZeroToHero.Domain.Enums;

namespace ZeroToHero.Application.Common.DTOs.EmployeeDtos;

public class AddEmployeeDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Role Role { get; set; }
}
