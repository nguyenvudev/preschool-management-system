using PreschoolManagementSystem.Application.DTOs.Students;

namespace  PreschoolManagementSystem.Application.DTOs.ClassRoom;
 public class ClassroomResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string GradeLevel { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int CurrentStudents { get; set; }
        public string? Description { get; set; }
        public string? RoomLocation { get; set; }
        public bool IsActive { get; set; }
        public int AcademicYear { get; set; }
        public int Semester { get; set; }
        // public TeacherDto? HeadTeacher { get; set; }
        // public TeacherDto? AssistantTeacher { get; set; }
        public List<StudentDto> Students { get; set; } = new();
        // public List<WeeklyScheduleDto> WeeklySchedules { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }