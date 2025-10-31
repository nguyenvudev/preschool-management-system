using AutoMapper;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Application.DTOs.Students;

namespace PreschoolManagementSystem.Application.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Students, StudentDto>().ReverseMap();
        }
    }
}
