using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Interfaces;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<List<Student>> GetByNameAsync(string name);
    Task<Student> GetByPhoneAsync(string phone);
    Task<Student> GetByEmailAsync(string email);
}
