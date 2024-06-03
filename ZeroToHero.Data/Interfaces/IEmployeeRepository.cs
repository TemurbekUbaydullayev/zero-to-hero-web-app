using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<List<Employee>> GetByNameAsync(string name);
    Task<Employee> GetByPhoneAsync(string phone);
    Task<Employee> GetByEmailAsync(string email);
}
