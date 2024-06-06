using ZeroToHero.Application.Common.DTOs.ResumeDtos;
using ZeroToHero.Application.Common.Utils;


namespace ZeroToHero.Application.Interfaces;

public interface IResumeService
{
    Task CreateAsync(AddResumeDto dto);
    Task<(string data, string filename)> GetCVAsync(string email); 
}