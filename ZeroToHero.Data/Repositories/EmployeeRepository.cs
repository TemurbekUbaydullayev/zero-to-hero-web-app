using Microsoft.EntityFrameworkCore;
using ZeroToHero.Data.DbContexts;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Repositories;
public class EmployeeRepository(AppDbContext dbContext) : GenericRepository<Employee>(dbContext), IEmployeeRepository
{
    public AppDbContext DbContext { get; } = dbContext;


    public async Task<List<Employee>> GetByNameAsync(string name)
    {
        var employes = await DbContext.Employees
                                      .Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name))
                                      .ToListAsync();
        return employes;
    }

    public async Task<Employee> GetByEmailAsync(string email)
    {
        var employee = await DbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);
        return employee;
    }

    public async Task<Employee> GetByPhoneAsync(string phone)
    {
        var employee = await DbContext.Employees.FirstOrDefaultAsync(e => e.Phone == phone);
        return employee;
    }
}
