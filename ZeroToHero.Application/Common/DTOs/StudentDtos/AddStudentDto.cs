using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using ZeroToHero.Application.Common.Attributes;
using ZeroToHero.Domain.Enums;

namespace ZeroToHero.Application.Common.DTOs.StudentDtos;

public class AddStudentDto
{
    [Required(ErrorMessage ="Firstname is required"),Length(2,20)]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Lastname is required"), Length(2, 20)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date of Birth is required")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage ="Gender not selected")]
    public Gender Gender { get; set; }

    [Required(ErrorMessage ="Phone is required"),Phone(ErrorMessage ="Phone format is incorrect")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Email format is incorrect")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage ="Password is required"),Password]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage ="Course id is required")]
    public int CourseId { get; set; }
}
