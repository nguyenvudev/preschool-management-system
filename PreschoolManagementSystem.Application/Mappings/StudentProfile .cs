using AutoMapper;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Application.DTOs.Students;
using PreschoolManagementSystem.Application.DTOs.Student;
using PreschoolManagementSystem.Application.Features.Students.Commands.CreateStudent;
using PreschoolManagementSystem.Application.Features.Students.Commands.UpdateStudent;

namespace PreschoolManagementSystem.Application.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            // CreateMap<CreateStudentRequest, CreateStudentCommand>();
            // CreateMap<CreateStudentCommand, Students>();
            // CreateMap<Students, StudentDto>().ReverseMap();
            // CreateMap<CreateStudentRequest, Students>();
            // CreateMap<UpdateStudentRequest, Students>();
            // CreateMap<Students, StudentDetailDto>();

            // Request -> Command
        CreateMap<CreateStudentRequest, CreateStudentCommand>();
        CreateMap<UpdateStudentRequest, UpdateStudentCommand>(); // Nếu có
        
        // Command -> Entity
        CreateMap<CreateStudentCommand, Students>();
        CreateMap<UpdateStudentRequest, Students>(); // Giữ lại nếu dùng cho Update
        
        // Entity -> DTOs (chỉ 1 chiều)
        CreateMap<Students, StudentDto>();
        CreateMap<Students, StudentDetailDto>();
        }
    }
}
