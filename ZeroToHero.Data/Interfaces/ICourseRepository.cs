using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Interfaces;

public interface ICourseRepository : IGenericRepository<Course>
{
    IQueryable<Course> GetByTitleAsync(string title);
}