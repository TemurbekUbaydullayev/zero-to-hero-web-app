using Microsoft.EntityFrameworkCore;
using ZeroToHero.Data.DbContexts;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Repositories;

public class CourseRepository(AppDbContext dbContext) : GenericRepository<Course>(dbContext), ICourseRepository
{
    public AppDbContext DbContext { get; } = dbContext;

    public async Task<List<Course>> GetByTitleAsync(string title)
    {
        var courses = await DbContext.Courses
                                     .Where(c => c.Title.Contains(title))
                                     .ToListAsync();

        return courses;
    }
}
