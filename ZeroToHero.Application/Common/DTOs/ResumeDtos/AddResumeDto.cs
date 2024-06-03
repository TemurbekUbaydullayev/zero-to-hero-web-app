using Microsoft.AspNetCore.Http;

namespace ZeroToHero.Application.Common.DTOs.ResumeDtos;

public class AddResumeDto
{
    public IFormFile ResumeFile { get; set; }
    public int StudentId { get; set; }
}
