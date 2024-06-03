namespace ZeroToHero.Data.Interfaces;

public interface IUnitOfWork
{
    ICourseRepository Courses { get; }
    IEmployeeRepository Employes { get; }
    IResumeRepository Resumes { get; }
    IStudentRepository Students { get; }
    IVideoRepository Videos { get; }
}
