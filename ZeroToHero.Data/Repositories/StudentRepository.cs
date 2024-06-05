using Microsoft.EntityFrameworkCore;
using ZeroToHero.Data.DbContexts;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.Repositories;

public class StudentRepository(AppDbContext dbContext) : GenericRepository<Student>(dbContext), IStudentRepository
{
    public AppDbContext DbContext { get; } = dbContext;


    public IQueryable<Student> GetByNameAsync(string name)

    {
        var students = DbContext.Students
                                       .Where(s => s.FirstName.Contains(name) || s.LastName.Contains(name));
        return students;
    }

    public async Task<Student> GetByEmailAsync(string email)
    {
        var student = await DbContext.Students.FirstOrDefaultAsync(s => s.Email == email);
        return student;
    }

    public async Task<Student> GetByPhoneAsync(string phone)
    {
        var student = await DbContext.Students.FirstOrDefaultAsync(s => s.Phone == phone);
        return student;
    }
}
