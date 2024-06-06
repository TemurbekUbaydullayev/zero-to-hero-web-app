namespace ZeroToHero.Application.Common.DTOs.ResumeDtos;

public class ResumeDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte Experience { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string[]? Links { get; set; }
    public string[]? Education { get; set; }
    public string[] Skills { get; set; } = null!;
    public string[] Languages { get; set; } = null!;
}