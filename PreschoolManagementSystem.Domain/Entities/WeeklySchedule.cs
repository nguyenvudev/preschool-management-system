// Domain/Entities/Schedule.cs
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities
{
    public class WeeklySchedule : BaseEntity
    {
        public Guid ClassroomId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? TeacherId { get; set; }
        public ScheduleType ScheduleType { get; set; } = ScheduleType.Regular;

        // Navigation properties
        public virtual Classroom Classroom { get; set; } = null!;
        public virtual User? Teacher { get; set; }
    }

}