using AutoMapper;
using System.Net;
using ZeroToHero.Application.Common.DTOs.StudentDtos;
using ZeroToHero.Application.Common.Exceptions;
using ZeroToHero.Application.Common.Extentions;
using ZeroToHero.Application.Common.Utils;
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

    public async Task<IEnumerable<StudentDto>> GetAllAsync(PaginationParams @params)
    {
        var students = await _unitOfWork.Students.GetAllAsync()
                                                                  .ToPagedListAsync(@params);

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

    public async Task UpdateAsync(UpdateStudentDto dto)
    {
        var model = await _unitOfWork.Students.GetByIdAsync(dto.Id);
        if (model is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Student not found");
        var student = _mapper.Map<Student>(dto);
        student.Id = dto.Id;
        student.Created_At = DateTime.Now;
        student.Password = model.Password;

        await _unitOfWork.Students.UpdateAsync(student);
        throw new StatusCodeException(HttpStatusCode.OK, "Student has been updated sucessfully");
    }
}
