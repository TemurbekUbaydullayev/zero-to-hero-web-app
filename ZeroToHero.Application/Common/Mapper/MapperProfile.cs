using AutoMapper;
using ZeroToHero.Application.Common.DTOs.CourseDtos;
using ZeroToHero.Application.Common.DTOs.EmployeeDtos;
using ZeroToHero.Application.Common.DTOs.StudentDtos;
using ZeroToHero.Application.Common.DTOs.VideoDtos;
using ZeroToHero.Domain.Entities;

namespace ZeroToHero.Application.Common.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Course, CourseDto>();
        CreateMap<Course, AddCourseDto>().ReverseMap();

        CreateMap<Video, VideoDto>();
        CreateMap<Video, AddVideoDto>().ReverseMap();

        CreateMap<Employee, EmployeeDto>();
        CreateMap<Employee, AddEmployeeDto>().ReverseMap();

        CreateMap<Student, StudentDto>();
        CreateMap<Student, AddStudentDto>().ReverseMap();
    }
}
