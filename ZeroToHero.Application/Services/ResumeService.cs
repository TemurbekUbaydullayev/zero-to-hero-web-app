using AutoMapper;
using System.Net;
using ZeroToHero.Application.Common.DTOs.ResumeDtos;
using ZeroToHero.Application.Common.Exceptions;
using ZeroToHero.Application.Common.Extentions;
using ZeroToHero.Application.Common.Utils;
using ZeroToHero.Application.Interfaces;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Application.Services;
public class ResumeService(IUnitOfWork unitOfWork,
                           IMapper mapper) : IResumeService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddResumeDto dto)
    {
        var resume = _mapper.Map<Resume>(dto);
        await _unitOfWork.Resumes.CreateAsync(resume);
    }

    public async Task DeleteAsync(int id)
    {
        var resume = await _unitOfWork.Resumes.GetByIdAsync(id);
        if (resume is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Resume Not Found");
        await _unitOfWork.Resumes.DeleteAsync(resume);
    }

    public async Task<IEnumerable<ResumeDto>> GetAllAsync(PaginationParams @params)
    {
        var resumes = await _unitOfWork.Resumes.GetAllAsync().ToPagedListAsync(@params);

        return resumes.Select(p => _mapper.Map<ResumeDto>(p));
    }

    public async Task<ResumeDto?> GetByIdAsync(int id)
    {
        var resume = await _unitOfWork.Resumes.GetByIdAsync(id);
        if (resume is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Resume not found");
        return _mapper.Map<ResumeDto>(resume);
    }

    public async Task UpdateAsync(ResumeDto dto)
    {
        var resume = await _unitOfWork.Resumes.GetByIdAsync(dto.Id);
        if (resume is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Resume not found");
        var resumes = _mapper.Map<Resume>(dto);
        resumes.Id = dto.Id;
        resumes.Created_At = DateTime.Now;
        resumes.Email = dto.Email;
        resumes.Phone = dto.Phone;
        resume.FirstName = dto.FirstName;
        resumes.LastName = dto.LastName;
        resumes.Summary = dto.Summary;
        resumes.Links = dto.Links;
        resumes.Skills = dto.Skills;
        resumes.Education = dto.Education;
        resumes.Experience = dto.Experience;

        await _unitOfWork.Resumes.UpdateAsync(resumes);
        throw new StatusCodeException(HttpStatusCode.OK, "Resume has been updated sucessfully");
    }
}
