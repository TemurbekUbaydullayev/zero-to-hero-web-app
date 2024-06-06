using ZeroToHero.Data.DbContexts;
using ZeroToHero.Data.Interfaces;

namespace ZeroToHero.Data.Repositories;

public class UnitOfWrok(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public ICourseRepository Courses => new CourseRepository(_dbContext);

    public IEmployeeRepository Employes => new EmployeeRepository(_dbContext);

    public IResumeRepository Resumes => new ResumeRepository(_dbContext);

    public IStudentRepository Students => new StudentRepository(_dbContext);

    public IVideoRepository Videos => new VideoRepository(_dbContext);

}
