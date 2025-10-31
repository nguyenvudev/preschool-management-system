// Domain/Entities/MenuMeal.cs
namespace PreschoolManagementSystem.Domain.Entities
{
    public class MenuMeal : BaseEntity
    {
        public Guid MenuId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public MealType MealType { get; set; }
        
        // Meal details
        public string DishName { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public string CookingInstructions { get; set; } = string.Empty;
        public string Allergens { get; set; } = string.Empty; // JSON array
        
        // Nutritional information per serving
        public decimal Calories { get; set; }
        public decimal Protein { get; set; }      // grams
        public decimal Fat { get; set; }          // grams
        public decimal Carbs { get; set; }        // grams
        public decimal Fiber { get; set; }        // grams
        public decimal Sugar { get; set; }        // grams
        
        public decimal ServingSize { get; set; }  // grams
        public string ServingUnit { get; set; } = "g";
        
        public string? Notes { get; set; }
        public string? ImageUrl { get; set; }

        // Navigation properties
        public virtual Menu Menu { get; set; } = null!;
    }

    public enum MealType
    {
        Breakfast = 1,      // Bữa sáng
        MorningSnack = 2,   // Ăn nhẹ sáng
        Lunch = 3,          // Bữa trưa
        AfternoonSnack = 4, // Ăn nhẹ chiều
        Dinner = 5          // Bữa tối (nếu có)
    }
}