using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Interfaces;

public interface IStudentRepository : IGenericRepository<Student>
{
    IQueryable<Student> GetByNameAsync(string name);
    Task<Student> GetByPhoneAsync(string phone);
    Task<Student> GetByEmailAsync(string email);
}
