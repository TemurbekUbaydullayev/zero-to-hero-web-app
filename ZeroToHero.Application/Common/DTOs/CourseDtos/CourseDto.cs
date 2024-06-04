namespace ZeroToHero.Application.Common.DTOs.CourseDtos;

public class CourseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int SellCount { get; set; }
    public byte Rank { get; set; }
    public List<string> Comments { get; set; } = new List<string>();
}