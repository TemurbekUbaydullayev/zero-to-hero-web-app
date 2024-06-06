using ZeroToHero.Application.Common.DTOs.ResumeDtos;

namespace ZeroToHero.Application.Interfaces;

public interface IResumeService
{
    Task CreateAsync(AddResumeDto dto);
    Task<(string data, string filename)> GetCVAsync(string email); 
}