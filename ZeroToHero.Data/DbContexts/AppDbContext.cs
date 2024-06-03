using Microsoft.EntityFrameworkCore;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses {get;set;}
    public DbSet<Employee> Employees {get;set;}
    public DbSet<Student> Students {get;set;}
    public DbSet<Video> Videos {get;set;}
}