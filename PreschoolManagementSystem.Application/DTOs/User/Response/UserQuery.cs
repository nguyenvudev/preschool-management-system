namespace PreschoolManagementSystem.Application.DTOs.Users
{
    public class UserQuery
    {
        public string? Search { get; set; }
        public string? Role { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
