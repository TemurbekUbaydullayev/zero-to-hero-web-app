namespace ZeroToHero.Domain.Entities;

public class Video : BaseEntity
{
    public int Duration {  get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string VideoPath { get; set; } = "";
}
