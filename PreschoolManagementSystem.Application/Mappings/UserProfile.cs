using AutoMapper;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Application.DTOs.Students;
using PreschoolManagementSystem.Application.DTOs.Student;
using PreschoolManagementSystem.Application.DTOs.Users;

namespace PreschoolManagementSystem.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, UserDetailDto>();
        
            
        }
    }
}
