namespace PreschoolManagementSystem.Application.DTOs.Users
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Role { get; set; } = default!;
        public string? PhoneNumber { get; set; }
    }
}
