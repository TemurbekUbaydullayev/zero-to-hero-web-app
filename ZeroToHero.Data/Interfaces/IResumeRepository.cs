using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Interfaces;

public interface IResumeRepository : IGenericRepository<Resume>
{
    Task<Resume> GetByEmailAsync(string email);
}