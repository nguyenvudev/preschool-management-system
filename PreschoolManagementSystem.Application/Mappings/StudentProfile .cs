using AutoMapper;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Application.DTOs.Students;
using PreschoolManagementSystem.Application.DTOs.Student;
using PreschoolManagementSystem.Application.Features.Students.Commands.CreateStudent;

namespace PreschoolManagementSystem.Application.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentRequest, CreateStudentCommand>();
            CreateMap<CreateStudentCommand, Students>();
            CreateMap<Students, StudentDto>().ReverseMap();
            CreateMap<CreateStudentRequest, Students>();
            CreateMap<UpdateStudentRequest, Students>();
            CreateMap<Students, StudentDetailDto>();
            CreateMap<CreateStudentCommand, Students>();

        }
    }
}
