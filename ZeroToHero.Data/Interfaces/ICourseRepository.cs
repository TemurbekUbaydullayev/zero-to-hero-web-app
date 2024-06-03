using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Interfaces;

public interface ICourseRepository : IGenericRepository<Course>
{
    Task<List<Course>> GetByTitleAsync(string title);
}
