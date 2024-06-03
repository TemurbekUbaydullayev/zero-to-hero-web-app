using Microsoft.EntityFrameworkCore;
using ZeroToHero.Data.DbContexts;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Repositories;

public class VideoRepository(AppDbContext dbContext) : GenericRepository<Video>(dbContext), IVideoRepository
{
    public AppDbContext DbContext { get; } = dbContext;

    public async Task<List<Video>> GetByTitleAsync(string title)
    {
        var videos = await DbContext.Videos
                                    .Where(v => v.Title.Contains(title))
                                    .ToListAsync();

        return videos;
    }
}
