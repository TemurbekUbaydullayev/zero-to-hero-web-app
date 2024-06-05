using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Interfaces;

public interface IVideoRepository : IGenericRepository<Video>
{
    IQueryable<Video> GetByTitleAsync(string title);
}