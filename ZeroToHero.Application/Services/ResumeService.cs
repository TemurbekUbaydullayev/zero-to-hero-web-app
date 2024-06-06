using AutoMapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using ZeroToHero.Application.Common.DTOs.ResumeDtos;
using ZeroToHero.Application.Interfaces;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Application.Services;

public class ResumeService(IFileService fileService,
                           IUnitOfWork unitOf,
                           IMapper mapper) : IResumeService
{
    private readonly IFileService _fileService = fileService;
    private readonly IUnitOfWork _unitOf = unitOf;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddResumeDto dto)
    {
        var resume = _mapper.Map<Resume>(dto);

        await _unitOf.Resumes.CreateAsync(resume);

        //var json = JsonConvert.SerializeObject(resume);

        //return (data: json, fileName: $"{resume.FirstName}-{resume.LastName}-CV.pdf");
    }

    public async Task<(string data, string filename)> GetCVAsync(string email)
    {
        var resume = await _unitOf.Resumes.GetByEmailAsync(email);
        var json = JsonConvert.SerializeObject(resume);

        return (data: json, filename: $"{resume.FirstName}-{resume.LastName}-CV.pdf");
    }
}
