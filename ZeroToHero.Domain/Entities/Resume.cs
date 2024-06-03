namespace ZeroToHero.Domain.Entities;

public  class Resume : BaseEntity
{
    public string FilePath { get; set; } = string.Empty;
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}
