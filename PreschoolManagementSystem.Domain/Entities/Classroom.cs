

using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Domain.Enums;

public class Classroom : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public GradeLevel GradeLevel { get; set; }
    public int Capacity { get; set; }
    public Guid? MainTeacherId { get; set; }
    public Guid? AssistantTeacherId { get; set; }
    public int AcademicYear { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
        

          // Navigation properties
        public virtual User? MainTeacher { get; set; }
        public virtual User? AssistantTeacher { get; set; }
        public virtual ICollection<Students> Students { get; set; } = new List<Students>();
        // public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}