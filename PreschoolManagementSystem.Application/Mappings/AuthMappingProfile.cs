// Application/Common/Mappings/AuthMappingProfile.cs
using AutoMapper;
using PreschoolManagementSystem.Application.DTOs.Auth;
using PreschoolManagementSystem.Application.DTOs.Auth.Requests;
using PreschoolManagementSystem.Application.DTOs.Users;
using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Application.Common.Mappings
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            // Map từ RegisterRequest sang User
            CreateMap<RegisterRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Bỏ qua Id vì tự generate
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Bỏ qua vì sẽ hash sau
                .ForMember(dest => dest.RefreshToken, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshTokenExpiryTime, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshTokens, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (Domain.Enums.UserRole)src.Role));

          CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        
        }
    }
}