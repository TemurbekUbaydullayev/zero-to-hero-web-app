using ZeroToHero.Application.Common.DTOs.ResumeDtos;
using ZeroToHero.Application.Common.Utils;

namespace ZeroToHero.Application.Interfaces;

public interface IResumeService
{
    Task CreateAsync(AddResumeDto dto);
    Task<ResumeDto?> GetByIdAsync(int id);
    Task<IEnumerable<ResumeDto>> GetAllAsync(PaginationParams @params);
    Task UpdateAsync(ResumeDto dto);
    Task DeleteAsync(int id);
}