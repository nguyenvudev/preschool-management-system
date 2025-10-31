// Application/DTOs/Auth/Responses/AuthResult.cs
using PreschoolManagementSystem.Application.DTOs.Users;

namespace PreschoolManagementSystem.Application.DTOs.Auth.Responses
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public UserDto? User { get; set; }
        public static AuthResult SuccessResult(string token, string refreshToken, UserDto user, string message = "")
        {
            return new AuthResult
            {
                Success = true,
                Message = message,
                Token = token,
                RefreshToken = refreshToken,
                User = user
            };
        }

        public static AuthResult ErrorResult(string message)
        {
            return new AuthResult
            {
                Success = false,
                Message = message
            };
        }
    }
}