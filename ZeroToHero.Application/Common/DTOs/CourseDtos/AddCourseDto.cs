using System.ComponentModel.DataAnnotations;

namespace ZeroToHero.Application.Common.DTOs.CourseDtos;

public class AddCourseDto
{
    [Required(ErrorMessage = "Couse name is required"), Length(2, 20)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Duration is required")]
    public int Duration { get; set; }
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Author is required")]
    public string Author { get; set; } = string.Empty;
}
