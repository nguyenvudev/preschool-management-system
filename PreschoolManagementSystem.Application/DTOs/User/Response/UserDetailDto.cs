namespace PreschoolManagementSystem.Application.DTOs.Users
{
    public class UserDetailDto : UserDto
    {
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
