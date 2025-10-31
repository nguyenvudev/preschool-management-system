// Domain/Entities/MenuClassroom.cs
namespace PreschoolManagementSystem.Domain.Entities
{
    public class MenuClassroom : BaseEntity
    {
        public Guid MenuId { get; set; }
        public Guid ClassroomId { get; set; }
        
        // Adjustments for specific classroom
        public decimal CalorieAdjustment { get; set; }
        public string? SpecialInstructions { get; set; }
        
        // Navigation properties
        public virtual Menu Menu { get; set; } = null!;
        public virtual Classroom Classroom { get; set; } = null!;
    }
}