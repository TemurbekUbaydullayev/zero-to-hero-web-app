using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Application.Interfaces;

public interface IAuthManager
{
    Task<string> LoginEmployeAsync(Employee employee);
    Task<string> LoginStudentAsync(Student student);
}
