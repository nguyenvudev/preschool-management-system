// Application/DTOs/Students/StudentDto.cs
namespace PreschoolManagementSystem.Application.DTOs.Students
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public string? ParentName { get; set; }
        public string? ParentPhone { get; set; }
        public string? ParentEmail { get; set; }
        public string? Address { get; set; }
        public string? BloodType { get; set; }
        public string? Allergies { get; set; }
        public string? MedicalConditions { get; set; }
        public string? EmergencyContact { get; set; }
        public string? EmergencyPhone { get; set; }
        public Guid? ClassroomId { get; set; }
        public string? ClassroomName { get; set; }
        public string Status { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}