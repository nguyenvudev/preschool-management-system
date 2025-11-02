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

    
      public async Task<AuthResult> RegisterAsync(RegisterRequest request)
    {
        try
        {
            // Kiểm tra email đã tồn tại
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                return AuthResult.ErrorResult("Email đã được sử dụng");

            // Kiểm tra số điện thoại đã tồn tại
            var existingPhone = await _userRepository.GetByPhoneNumberAsync(request.PhoneNumber);
            if (existingPhone != null)
                return AuthResult.ErrorResult("Số điện thoại đã được sử dụng");

            // Map từ RegisterRequest sang User entity
            var user = _mapper.Map<User>(request);
            user.Id = Guid.NewGuid();
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.IsActive = true;
            user.CreatedAt = DateTime.UtcNow;

            await _userRepository.AddAsync(user);

            // Generate tokens
            var token = _tokenService.GenerateToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            // Lưu refresh token
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateAsync(user);

            // Map User entity sang UserDto
            var userDto = _mapper.Map<UserDto>(user);

            return AuthResult.SuccessResult(token, refreshToken, userDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during registration for {Email}", request.Email);
            return AuthResult.ErrorResult("Đăng ký thất bại");
        }
    }
    }
}