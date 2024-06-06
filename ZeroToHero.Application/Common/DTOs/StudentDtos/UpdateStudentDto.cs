using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using ZeroToHero.Application.Common.Attributes;
using ZeroToHero.Domain.Enums;

namespace ZeroToHero.Application.Common.DTOs.StudentDtos;

public class UpdateStudentDto : AddStudentDto
{
    public int Id { get; set; }
}