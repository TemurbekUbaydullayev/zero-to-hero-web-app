using ZeroToHero.Application.Common.DTOs.CourseDtos;
using ZeroToHero.Domain.Enums;

namespace ZeroToHero.Application.Common.DTOs.StudentDtos;

public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public CourseDto Course { get; set; } = null!;
}
