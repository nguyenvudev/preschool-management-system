using PreschoolManagementSystem.Application.Common.Models;
using PreschoolManagementSystem.Application.DTOs.Common;
using PreschoolManagementSystem.Application.DTOs.Users;

namespace PreschoolManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<PagedResponse<UserDto>> GetUsersAsync(UserQuery query);
        Task<UserDetailDto?> GetUserByIdAsync(Guid id);
        Task<UserDto> CreateUserAsync(CreateUserRequest request);
        Task<UserDto> UpdateUserAsync(UpdateUserRequest request);
        Task DeleteUserAsync(Guid id);
        Task ToggleUserStatusAsync(Guid id);
    }
}
