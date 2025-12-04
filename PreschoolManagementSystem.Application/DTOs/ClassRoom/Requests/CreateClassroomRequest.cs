// Application/DTOs/Classrooms/Requests/CreateClassroomRequest.cs
namespace PreschoolManagementSystem.Application.DTOs.Classrooms.Requests
{
    public class CreateClassroomRequest
    {
        public string Name { get; set; } = string.Empty;
        public string GradeLevel { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public Guid? MainTeacherId { get; set; }
        public Guid? AssistantTeacherId { get; set; }
        public int AcademicYear { get; set; }
        public string? Description { get; set; }
    }
}