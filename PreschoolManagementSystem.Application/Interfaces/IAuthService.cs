using PreschoolManagementSystem.Application.DTOs.Auth.Requests;
using PreschoolManagementSystem.Application.DTOs.Auth.Responses;
using PreschoolManagementSystem.Application.DTOs.Users;

namespace PreschoolManagementSystem.Application.Interfaces
{
    public interface IAuthService
    {


        Task<AuthResult> LoginAsync(LoginRequest request);
        Task<AuthResult> RefreshTokenAsync(string refreshToken);
        Task RevokeRefreshTokenAsync(Guid userId);
        Task<UserDto?> GetUserProfileAsync(Guid userId);
        Task<AuthResult> ChangePasswordAsync(ChangePasswordRequest request);
        Task<AuthResult> RegisterAsync(RegisterUserRequest request);

    }
}