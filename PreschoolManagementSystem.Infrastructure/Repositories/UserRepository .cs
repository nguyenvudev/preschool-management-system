// Infrastructure/Repositories/UserRepository.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PreschoolManagementSystem.Application.Common.Models;
using PreschoolManagementSystem.Application.Interfaces.Repositories;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Domain.Enums;
using PreschoolManagementSystem.Infrastructure.Data;

namespace PreschoolManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
    private readonly PreschoolDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(PreschoolDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id && u.IsActive);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.IsActive);
        }

        public async Task<List<User>> GetByRoleAsync(UserRole role)
        {
            return await _context.Users
                .Where(u => u.Role == role && u.IsActive)
                .OrderBy(u => u.FullName)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Where(u => u.IsActive)
                .OrderBy(u => u.FullName)
                .ToListAsync();
        }

        public async Task<PagedList<User>> GetPagedAsync(int page = 1, int pageSize = 10, string? search = null, string? role = null)
        {
            var query = _context.Users
                .Where(u => u.IsActive)
                .AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(u => 
                    u.FullName.Contains(search) || 
                    u.Email.Contains(search) ||
                    u.PhoneNumber.Contains(search));
            }

            // Apply role filter
            if (!string.IsNullOrWhiteSpace(role) && Enum.TryParse<UserRole>(role, out var userRole))
            {
                query = query.Where(u => u.Role == userRole);
            }

            var totalCount = await query.CountAsync();

            var users = await query
                .OrderBy(u => u.FullName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<User>
            {
                Data = users,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<bool> EmailExistsAsync(string email, Guid? excludeUserId = null)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email && u.IsActive && u.Id != excludeUserId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task AddRefreshTokenAsync(Guid userId, string refreshToken)
        {
            var refreshTokenEntity = new RefreshToken
            {
                UserId = userId,
                Token = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            _context.RefreshTokens.Add(refreshTokenEntity);
        }

        public async Task<Guid?> ValidateRefreshTokenAsync(string refreshToken)
        {
            var token = await _context.RefreshTokens
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(rt => rt.Token == refreshToken && 
                                         rt.ExpiresAt > DateTime.UtcNow && 
                                         rt.RevokedAt == null &&
                                         rt.User.IsActive);

            return token?.UserId;
        }

        public async Task UpdateRefreshTokenAsync(string oldToken, string newToken)
        {
            var existingToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == oldToken && rt.ExpiresAt > DateTime.UtcNow);

            if (existingToken != null)
            {
                existingToken.RevokedAt = DateTime.UtcNow;
                existingToken.ReplacedByToken = newToken;

                var newRefreshToken = new RefreshToken
                {
                    UserId = existingToken.UserId,
                    Token = newToken,
                    ExpiresAt = DateTime.UtcNow.AddDays(7)
                };

                _context.RefreshTokens.Add(newRefreshToken);
            }
        }

        public async Task RevokeRefreshTokensAsync(Guid userId)
        {
            var tokens = await _context.RefreshTokens
                .Where(rt => rt.UserId == userId && rt.RevokedAt == null)
                .ToListAsync();

            foreach (var token in tokens)
            {
                token.RevokedAt = DateTime.UtcNow;
                token.RevocationReason = "Logged out";
            }
        }

        public async Task<List<RefreshToken>> GetUserRefreshTokensAsync(Guid userId)
        {
            return await _context.RefreshTokens
                .Where(rt => rt.UserId == userId)
                .OrderByDescending(rt => rt.CreatedAt)
                .ToListAsync();
        }

        public Task<PagedList<User>> GetPagedAsync(UserQuery query)
        {
            throw new NotImplementedException();
        }
    }
}