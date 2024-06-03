using ZeroToHero.Data.DbContexts;
using ZeroToHero.Data.Interfaces;

namespace ZeroToHero.Data.Repositories;

public class UnitOfWrok(AppDbContext dbContext) : IUnitOfWork
{
    public AppDbContext DbContext { get; } = dbContext;

    public ICourseRepository Courses => throw new NotImplementedException();

    public IEmployeeRepository Employes => throw new NotImplementedException();

    public IResumeRepository Resumes => throw new NotImplementedException();

    public IStudentRepository Students => throw new NotImplementedException();

    public IVideoRepository Videos => throw new NotImplementedException();

}
