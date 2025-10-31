// Application/Interfaces/Repositories/IUserRepository.cs
using PreschoolManagementSystem.Application.Common.Models;
using PreschoolManagementSystem.Application.DTOs.Common;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task<List<User>> GetByRoleAsync(UserRole role);
        Task<List<User>> GetAllAsync();
        Task<PagedList<User>> GetPagedAsync(UserQuery query);
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<bool> EmailExistsAsync(string email, Guid? excludeUserId = null);
        Task<int> SaveChangesAsync();
        
        // Refresh Token methods
        Task AddRefreshTokenAsync(Guid userId, string refreshToken);
        Task<Guid?> ValidateRefreshTokenAsync(string refreshToken);
        Task UpdateRefreshTokenAsync(string oldToken, string newToken);
        Task RevokeRefreshTokensAsync(Guid userId);
        Task<List<RefreshToken>> GetUserRefreshTokensAsync(Guid userId);
    }

    public class UserQuery : PaginationQuery
    {
        public string? Role { get; set; }
        public bool? IsActive { get; set; }
    }
}