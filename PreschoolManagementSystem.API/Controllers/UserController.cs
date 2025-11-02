// WebAPI/Controllers/UsersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreschoolManagementSystem.Application.Common.Models;
using PreschoolManagementSystem.Application.DTOs.Common;
using PreschoolManagementSystem.Application.DTOs.Users;
using PreschoolManagementSystem.Application.Interfaces;
using PreschoolManagementSystem.Application.Interfaces.Repositories;

namespace PreschoolManagementSystem.WebAPI.Controllers
{
    [Authorize(Roles = "Admin")] // Chỉ Admin được quản lý người dùng
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResponse<UserDto>>>> GetAll([FromQuery] Application.DTOs.Users.UserQuery query)
        {
            try
            {
                var users = await _userService.GetUsersAsync(query);
                return Ok(ApiResponse<PagedResponse<UserDto>>.SuccessResult(users));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi lấy danh sách người dùng");
                return StatusCode(500, ApiResponse<PagedResponse<UserDto>>.ErrorResult("Lỗi lấy danh sách người dùng"));
            }
        }

        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<UserDetailDto>>> GetById(Guid id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound(ApiResponse<UserDetailDto>.ErrorResult("Không tìm thấy người dùng"));

                return Ok(ApiResponse<UserDetailDto>.SuccessResult(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi lấy thông tin người dùng {Id}", id);
                return StatusCode(500, ApiResponse<UserDetailDto>.ErrorResult("Lỗi hệ thống"));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<UserDto>>> Create(CreateUserRequest request)
        {
            try
            {
                var created = await _userService.CreateUserAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = created.Id },
                    ApiResponse<UserDto>.SuccessResult(created, "Tạo người dùng thành công"));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<UserDto>.ErrorResult(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi tạo người dùng");
                return StatusCode(500, ApiResponse<UserDto>.ErrorResult("Lỗi tạo người dùng"));
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<UserDto>>> Update(Guid id, UpdateUserRequest request)
        {
            try
            {
                if (id != request.Id)
                    return BadRequest(ApiResponse<UserDto>.ErrorResult("ID không khớp"));

                var updated = await _userService.UpdateUserAsync(request);
                return Ok(ApiResponse<UserDto>.SuccessResult(updated, "Cập nhật thành công"));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<UserDto>.ErrorResult(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi cập nhật người dùng {Id}", id);
                return StatusCode(500, ApiResponse<UserDto>.ErrorResult("Lỗi cập nhật người dùng"));
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok(ApiResponse<object>.SuccessResult(null, "Xóa người dùng thành công"));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ApiResponse<object>.ErrorResult(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi xóa người dùng {Id}", id);
                return StatusCode(500, ApiResponse<object>.ErrorResult("Lỗi xóa người dùng"));
            }
        }

        [HttpPut("{id:guid}/toggle-active")]
        public async Task<ActionResult<ApiResponse<object>>> ToggleActive(Guid id)
        {
            try
            {
                await _userService.ToggleUserStatusAsync(id);
                return Ok(ApiResponse<object>.SuccessResult(null, "Thay đổi trạng thái người dùng thành công"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi thay đổi trạng thái người dùng {Id}", id);
                return StatusCode(500, ApiResponse<object>.ErrorResult("Lỗi thay đổi trạng thái"));
            }
        }
    }
}
