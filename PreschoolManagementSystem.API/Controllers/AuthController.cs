// WebAPI/Controllers/AuthController.cs
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PreschoolManagementSystem.Application.Common.Models;
using PreschoolManagementSystem.Application.DTOs.Auth;
using PreschoolManagementSystem.Application.DTOs.Auth.Requests;
using PreschoolManagementSystem.Application.DTOs.Auth.Responses;
using PreschoolManagementSystem.Application.DTOs.Users;
using PreschoolManagementSystem.Application.Interfaces;

namespace PreschoolManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> Login(LoginRequest request)
        {
            try
            {
                var result = await _authService.LoginAsync(request);
                
                if (!result.Success)
                    return BadRequest(ApiResponse<AuthResponse>.ErrorResult(result.Message));

                SetRefreshTokenCookie(result.RefreshToken!);
                
                var response = new AuthResponse
                {
                    Token = result.Token!,
                    User = result.User!
                };

                return Ok(ApiResponse<AuthResponse>.SuccessResult(response, "Đăng nhập thành công"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login error for {Email}", request.Email);
                return StatusCode(500, ApiResponse<AuthResponse>.ErrorResult("Lỗi hệ thống"));
            }
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> RefreshToken()
        {
            try
            {
                var refreshToken = Request.Cookies["refreshToken"];
                
                if (string.IsNullOrEmpty(refreshToken))
                    return Unauthorized(ApiResponse<AuthResponse>.ErrorResult("Token không hợp lệ"));

                var result = await _authService.RefreshTokenAsync(refreshToken);
                
                if (!result.Success)
                    return Unauthorized(ApiResponse<AuthResponse>.ErrorResult(result.Message));

                SetRefreshTokenCookie(result.RefreshToken!);
                
                var response = new AuthResponse
                {
                    Token = result.Token!,
                    User = result.User!
                };

                return Ok(ApiResponse<AuthResponse>.SuccessResult(response, "Làm mới token thành công"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Refresh token error");
                return StatusCode(500, ApiResponse<AuthResponse>.ErrorResult("Lỗi làm mới token"));
            }
        }

        [HttpPost("logout")]
        public async Task<ActionResult<ApiResponse<object>>> Logout()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                
                if (userId != null && Guid.TryParse(userId, out var userGuid))
                    await _authService.RevokeRefreshTokenAsync(userGuid);

                Response.Cookies.Delete("refreshToken");
                return Ok(ApiResponse<object>.SuccessResult(null, "Đăng xuất thành công"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Logout error");
                return StatusCode(500, ApiResponse<object>.ErrorResult("Lỗi đăng xuất"));
            }
        }

        [HttpGet("profile")]
        public async Task<ActionResult<ApiResponse<UserDto>>> GetProfile()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                
                if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
                    return Unauthorized(ApiResponse<UserDto>.ErrorResult("Không xác thực được người dùng"));

                var user = await _authService.GetUserProfileAsync(userGuid);
                
                if (user == null)
                    return NotFound(ApiResponse<UserDto>.ErrorResult("Không tìm thấy người dùng"));

                return Ok(ApiResponse<UserDto>.SuccessResult(user, "Lấy thông tin thành công"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get profile error");
                return StatusCode(500, ApiResponse<UserDto>.ErrorResult("Lỗi lấy thông tin"));
            }
        }

        [HttpPost("change-password")]
        public async Task<ActionResult<ApiResponse<object>>> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                
                if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
                    return Unauthorized(ApiResponse<object>.ErrorResult("Không xác thực được người dùng"));

                request.UserId = userGuid;
                var result = await _authService.ChangePasswordAsync(request);
                
                if (!result.Success)
                    return BadRequest(ApiResponse<object>.ErrorResult(result.Message));

                return Ok(ApiResponse<object>.SuccessResult(null, "Đổi mật khẩu thành công"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Change password error");
                return StatusCode(500, ApiResponse<object>.ErrorResult("Lỗi đổi mật khẩu"));
            }
        }

        private void SetRefreshTokenCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7),
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Path = "/"
            };
            
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}