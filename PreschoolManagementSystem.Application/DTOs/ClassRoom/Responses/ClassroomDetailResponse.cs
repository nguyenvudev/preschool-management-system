using PreschoolManagementSystem.Domain.Enums;

namespace  PreschoolManagementSystem.Application.DTOs.ClassRoom
{
 public class ClassroomDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public GradeLevel GradeLevel { get; set; }
        public int Capacity { get; set; }
        public int CurrentStudents { get; set; }
        public Guid? MainTeacherId { get; set; }
        public string? MainTeacherName { get; set; }
        public Guid? AssistantTeacherId { get; set; }
        public string? AssistantTeacherName { get; set; }
        public int AcademicYear { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Additional details
        // public List<ClassroomStudentResponse> Students { get; set; } = new();
        // public List<WeeklyScheduleResponse> Schedules { get; set; } = new();
    }
}