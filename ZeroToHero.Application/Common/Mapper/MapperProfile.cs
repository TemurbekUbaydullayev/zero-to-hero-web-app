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
        CreateMap<Course, AddCourseDto>();
        CreateMap<Course, CourseDto>().ReverseMap();

        CreateMap<Video, AddVideoDto>();
        CreateMap<Video, VideoDto>().ReverseMap();

        CreateMap<Employee, AddEmployeeDto>();
        CreateMap<Employee, EmployeeDto>().ReverseMap();

        CreateMap<AddStudentDto, Student>();
        CreateMap<Student, StudentDto>().ReverseMap();
    }
}
