// Domain/Entities/NutritionRecord.cs
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities
{
    public class NutritionRecord : BaseEntity
    {
        public Guid StudentId { get; set; }
        public DateTime RecordDate { get; set; }
        public MealType MealType { get; set; }
        
        // Consumption tracking
        public ConsumptionAmount ConsumptionAmount { get; set; }
        public decimal ActualCalories { get; set; }
        public string? FoodItems { get; set; } // JSON array of consumed items
        
        // Student behavior
        public EatingBehavior Behavior { get; set; }
        public string? Notes { get; set; }
        public string? AllergicReactions { get; set; }
        
        public Guid RecordedById { get; set; }

        // Navigation properties
        public virtual Students Students { get; set; } = null!;
        public virtual User RecordedBy { get; set; } = null!;
    }


   
}