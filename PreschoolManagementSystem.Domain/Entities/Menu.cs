// Domain/Entities/Menu.cs
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public MenuType MenuType { get; set; }
        public Season Season { get; set; }
        
        // Nutritional totals
        public decimal TotalCalories { get; set; }
        public decimal TotalProtein { get; set; }    // grams
        public decimal TotalFat { get; set; }        // grams
        public decimal TotalCarbs { get; set; }      // grams
        public decimal TotalFiber { get; set; }      // grams
        public decimal TotalSugar { get; set; }      // grams
        
        public bool IsActive { get; set; } = true;
        public Guid CreatedById { get; set; }
        
        // Navigation properties
        public virtual User CreatedBy { get; set; } = null!;
        public virtual ICollection<MenuMeal> Meals { get; set; } = new List<MenuMeal>();
        public virtual ICollection<MenuClassroom> MenuClassrooms { get; set; } = new List<MenuClassroom>();
    }

  
   
}