namespace PreschoolManagementSystem.Domain.Entities
{
    public class DailySchedule : BaseEntity
    {
        public DayOfWeek DayOfWeek { get; set; }
        public DateOnly Date { get; set; } // Ngày cụ thể
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ActivityType { get; set; } = string.Empty; // Học tập, Vui chơi, Ăn uống, Ngủ trưa
        public Guid WeeklyScheduleId { get; set; }
        
        public virtual WeeklySchedule WeeklySchedule { get; set; } = null!;
    }
}