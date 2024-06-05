using ZeroToHero.Application.Common.DTOs.StudentDtos;
using ZeroToHero.Application.Common.Utils;

namespace ZeroToHero.Application.Interfaces;

public interface IStudentService
{
    Task RegisterAsync(AddStudentDto dto);
    Task<IEnumerable<StudentDto>> GetAllAsync(PaginationParams @params);
    Task<StudentDto> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task UpdateAsync(UpdateStudentDto dto);
}
