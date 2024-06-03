namespace ZeroToHero.Application.Common.DTOs.CourseDtos;

public class AddCourseDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
}
