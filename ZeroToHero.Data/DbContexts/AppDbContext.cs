using Microsoft.EntityFrameworkCore;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses {get;set;}
    public DbSet<Employee> Employees {get;set;}
    public DbSet<Resume> Resumes {get;set;}
    public DbSet<Student> Students {get;set;}
    public DbSet<Video> Videos {get;set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = 1,
            FirstName = "Super",
            LastName = "Admin",
            Email = "superadmin@gmail.com",
            Phone = "+998200000000",
            Role = Domain.Enums.Role.Admin,
            IsActive = true
        });
    }
}
