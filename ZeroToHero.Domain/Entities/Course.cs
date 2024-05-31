namespace ZeroToHero.Domain.Entities;

public class Course : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int SellCount { get; set; }
    public byte Rank { get; set; }
    public string Comments { get; set; } = string.Empty;

}
