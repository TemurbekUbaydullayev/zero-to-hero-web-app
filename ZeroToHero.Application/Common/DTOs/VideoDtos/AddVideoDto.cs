namespace ZeroToHero.Application.Common.DTOs.VideoDtos;

public class AddVideoDto
{
    public int Duration { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string VideoPath { get; set; } = string.Empty;
}
