// Domain/Entities/Schedule.cs
namespace PreschoolManagementSystem.Domain.Entities
{
    public class Schedule : BaseEntity
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

    public enum ScheduleType
    {
        Regular = 1,      // Lịch học thường ngày
        Special = 2,      // Hoạt động đặc biệt
        Outdoor = 3,      // Hoạt động ngoài trời
        NapTime = 4       // Giờ ngủ trưa
    }
}