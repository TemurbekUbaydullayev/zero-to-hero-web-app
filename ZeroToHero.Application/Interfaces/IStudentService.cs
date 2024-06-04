using ZeroToHero.Application.Common.DTOs.StudentDtos;

namespace ZeroToHero.Application.Interfaces;

public interface IStudentService
{
    Task RegisterAsync(AddStudentDto dto);
    Task<List<StudentDto>> GetAllAsync();
    Task<StudentDto> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task UpdateAsync(AddStudentDto dto);
}
