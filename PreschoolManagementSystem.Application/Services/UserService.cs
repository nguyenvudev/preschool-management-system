using AutoMapper;
using PreschoolManagementSystem.Application.DTOs.Users;
using PreschoolManagementSystem.Application.Interfaces.Repositories;
using PreschoolManagementSystem.Application.Interfaces;
using PreschoolManagementSystem.Application.Common.Models;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Domain.Enums;
using PreschoolManagementSystem.Application.DTOs.Common;

namespace PreschoolManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<PagedResponse<UserDto>> GetUsersAsync(DTOs.Users.UserQuery query)
        {
            var pagedUsers = await _userRepository.GetPagedAsync(
                query.PageIndex, query.PageSize, query.Search, query.Role
            );

            var userDtos = _mapper.Map<List<UserDto>>(pagedUsers.Data);

            return new PagedResponse<UserDto>(userDtos, pagedUsers.TotalCount, query.PageIndex, query.PageSize);
        }

        public async Task<UserDetailDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDetailDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(CreateUserRequest request)
        {
            if (await _userRepository.EmailExistsAsync(request.Email))
                throw new ArgumentException("Email đã tồn tại");

            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                Role = Enum.Parse<UserRole>(request.Role, true),
                PhoneNumber = request.PhoneNumber,
                PasswordHash = _passwordHasher.HashPassword(request.Password),
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(UpdateUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new ArgumentException("Không tìm thấy người dùng");

            user.FullName = request.FullName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.Role = Enum.Parse<UserRole>(request.Role, true);

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new ArgumentException("Không tìm thấy người dùng");

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task ToggleUserStatusAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new ArgumentException("Không tìm thấy người dùng");

            user.IsActive = !user.IsActive;
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

     
    }
}
