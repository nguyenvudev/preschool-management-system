// Application/Services/AuthService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using PreschoolManagementSystem.Application.DTOs.Auth.Requests;
using PreschoolManagementSystem.Application.DTOs.Auth.Responses;
using PreschoolManagementSystem.Application.DTOs.Users;
using PreschoolManagementSystem.Application.Interfaces;
using PreschoolManagementSystem.Application.Interfaces.Repositories;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IPasswordHasher passwordHasher,
            IMapper mapper,
            ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AuthResult> LoginAsync(LoginRequest request)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(request.Email);
                
                if (user == null || !user.IsActive)
                {
                    _logger.LogWarning("Login failed for email: {Email} - User not found or inactive", request.Email);
                    return new AuthResult { Success = false, Message = "Email hoặc mật khẩu không đúng" };
                }

                if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
                {
                    _logger.LogWarning("Login failed for email: {Email} - Invalid password", request.Email);
                    return new AuthResult { Success = false, Message = "Email hoặc mật khẩu không đúng" };
                }

                var token = _tokenService.GenerateToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                // Save refresh token
                await _userRepository.AddRefreshTokenAsync(user.Id, refreshToken);
                await _userRepository.SaveChangesAsync();

                var userDto = _mapper.Map<UserDto>(user);

                _logger.LogInformation("User {Email} logged in successfully", request.Email);
                return new AuthResult
                {
                    Success = true,
                    Token = token,
                    RefreshToken = refreshToken,
                    User = userDto
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for email: {Email}", request.Email);
                return new AuthResult { Success = false, Message = "Đã xảy ra lỗi trong quá trình đăng nhập" };
            }
        }

        public async Task<AuthResult> RefreshTokenAsync(string refreshToken)
        {
            try
            {
                var userId = await _userRepository.ValidateRefreshTokenAsync(refreshToken);
                if (userId == null)
                {
                    _logger.LogWarning("Refresh token validation failed");
                    return new AuthResult { Success = false, Message = "Refresh token không hợp lệ" };
                }

                var user = await _userRepository.GetByIdAsync(userId.Value);
                if (user == null || !user.IsActive)
                {
                    _logger.LogWarning("Refresh token failed for user {UserId} - User not found or inactive", userId);
                    return new AuthResult { Success = false, Message = "Người dùng không tồn tại hoặc đã bị vô hiệu hóa" };
                }

                var newToken = _tokenService.GenerateToken(user);
                var newRefreshToken = _tokenService.GenerateRefreshToken();

                // Update refresh token
                await _userRepository.UpdateRefreshTokenAsync(refreshToken, newRefreshToken);
                await _userRepository.SaveChangesAsync();

                var userDto = _mapper.Map<UserDto>(user);

                _logger.LogInformation("Token refreshed successfully for user {Email}", user.Email);
                return new AuthResult
                {
                    Success = true,
                    Token = newToken,
                    RefreshToken = newRefreshToken,
                    User = userDto
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error refreshing token");
                return new AuthResult { Success = false, Message = "Đã xảy ra lỗi khi làm mới token" };
            }
        }

        public async Task<AuthResult> RegisterAsync(RegisterUserRequest request)
        {
            try
            {
                // Check if email already exists
                if (await _userRepository.EmailExistsAsync(request.Email))
                {
                    return new AuthResult { Success = false, Message = "Email đã tồn tại trong hệ thống" };
                }

                var user = new User
                {
                    Email = request.Email,
                    PasswordHash = _passwordHasher.HashPassword(request.Password),
                    FullName = request.FullName,
                    Role = UserRole.Teacher, // Default role for new registrations
                    PhoneNumber = request.PhoneNumber,
                    PreschoolId = Guid.NewGuid(), // In real app, this should come from organization context
                    IsActive = true
                };

                var createdUser = await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                var userDto = _mapper.Map<UserDto>(createdUser);

                _logger.LogInformation("New user registered: {Email}", request.Email);
                return new AuthResult
                {
                    Success = true,
                    Message = "Đăng ký tài khoản thành công",
                    User = userDto
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering user: {Email}", request.Email);
                return new AuthResult { Success = false, Message = "Đã xảy ra lỗi trong quá trình đăng ký" };
            }
        }

        public async Task RevokeRefreshTokenAsync(Guid userId)
        {
            try
            {
                await _userRepository.RevokeRefreshTokensAsync(userId);
                await _userRepository.SaveChangesAsync();
                _logger.LogInformation("Refresh tokens revoked for user {UserId}", userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error revoking refresh tokens for user {UserId}", userId);
                throw;
            }
        }

        public async Task<UserDto?> GetUserProfileAsync(Guid userId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                return user == null ? null : _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting profile for user {UserId}", userId);
                throw;
            }
        }

        public async Task<AuthResult> ChangePasswordAsync(ChangePasswordRequest request)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.UserId);
                if (user == null)
                {
                    return new AuthResult { Success = false, Message = "Người dùng không tồn tại" };
                }

                if (!_passwordHasher.VerifyPassword(request.CurrentPassword, user.PasswordHash))
                {
                    return new AuthResult { Success = false, Message = "Mật khẩu hiện tại không đúng" };
                }

                user.PasswordHash = _passwordHasher.HashPassword(request.NewPassword);
                await _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangesAsync();

                _logger.LogInformation("Password changed successfully for user {UserId}", request.UserId);
                return new AuthResult { Success = true, Message = "Đổi mật khẩu thành công" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error changing password for user {UserId}", request.UserId);
                return new AuthResult { Success = false, Message = "Đã xảy ra lỗi khi đổi mật khẩu" };
            }
        }
    }
}