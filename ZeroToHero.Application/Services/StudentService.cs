using AutoMapper;
using System.Net;
using ZeroToHero.Application.Common.DTOs.StudentDtos;
using ZeroToHero.Application.Common.Exceptions;
using ZeroToHero.Application.Interfaces;
using ZeroToHero.Data.Interfaces;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Application.Services;
public class StudentService(IUnitOfWork unitOfWork,
                            IMapper mapper) 
    : IStudentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;  

    public async Task DeleteAsync(int id)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(id);
        if (student is null)
            throw new StatusCodeException(HttpStatusCode.NotFound,"Student Not Found");
        await _unitOfWork.Students.DeleteAsync(student);
    }

    public async Task<List<StudentDto>> GetAllAsync()
    {
        var students = await _unitOfWork.Students.GetAllAsync();
        return students.Select(x => _mapper.Map<StudentDto>(x)).ToList();
    }


    public async Task<StudentDto> GetByIdAsync(int id)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(id);
        if (student is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Student not found");
        return _mapper.Map<StudentDto>(student);
    }

    public async Task RegisterAsync(AddStudentDto dto)
    {
        var student = await _unitOfWork.Students.GetByEmailAsync(dto.Email);
        if (student is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, $"{dto.Email} was registered");
    }

    public Task UpdateAsync(AddStudentDto dto)
    {
        throw new NotImplementedException();
    }
}
