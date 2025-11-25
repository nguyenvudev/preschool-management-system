namespace PreschoolManagementSystem.Domain.Entities
{
     // Hoạt động trong tuần
    public class WeeklyActivity : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ActivityType { get; set; } = string.Empty; // Dã ngoại, Lễ hội, Hội thao
        public string? Location { get; set; }
        public string? MaterialsNeeded { get; set; }
        public string? Notes { get; set; }
        public Guid WeeklyScheduleId { get; set; }
        
        public virtual WeeklySchedule WeeklySchedule { get; set; } = null!;
    }
}