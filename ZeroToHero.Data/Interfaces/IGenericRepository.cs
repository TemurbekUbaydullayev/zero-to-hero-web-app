using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
