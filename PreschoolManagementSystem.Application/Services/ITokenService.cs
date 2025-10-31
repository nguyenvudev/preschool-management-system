using System.Security.Claims;
using PreschoolManagementSystem.Domain.Entities;

using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);    }
}