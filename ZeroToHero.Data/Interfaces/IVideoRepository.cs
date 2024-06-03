using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Interfaces;

public interface IVideoRepository : IGenericRepository<Video>
{
    Task<List<Video>> GetByTitleAsync(string title);
}
