// Application/DTOs/Auth/Responses/AuthResponse.cs
using PreschoolManagementSystem.Application.DTOs.Users;

namespace PreschoolManagementSystem.Application.DTOs.Auth.Responses
{
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public UserDto User { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
    }
}