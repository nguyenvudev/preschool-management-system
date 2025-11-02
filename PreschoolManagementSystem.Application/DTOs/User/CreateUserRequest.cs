namespace PreschoolManagementSystem.Application.DTOs.Users
{
    public class CreateUserRequest
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = "Teacher"; // mặc định
        public string? PhoneNumber { get; set; }
    }
}
