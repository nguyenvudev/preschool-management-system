

using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Domain.Enums;

public class Classroom : BaseEntity
{
  public string Name { get; set; } = string.Empty;
  public GradeLevel GradeLevel { get; set; }
  public int Capacity { get; set; }

  public int CurrentStudents => Students?.Count(s => s.Status == StudentStatus.Active) ?? 0;

  public Guid? MainTeacherId { get; set; }
  public Guid? AssistantTeacherId { get; set; }
  public int AcademicYear { get; set; }
  public string? Description { get; set; }
  public bool IsActive { get; set; } = true;


  // Navigation properties
  public virtual User? MainTeacher { get; set; }
  public virtual User? AssistantTeacher { get; set; }
  public virtual ICollection<Students> Students { get; set; } = new List<Students>();
  public virtual ICollection<WeeklySchedule> Schedules { get; set; } = new List<WeeklySchedule>();
  public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}