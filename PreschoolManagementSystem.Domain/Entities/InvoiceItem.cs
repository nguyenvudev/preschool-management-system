// Domain/Entities/InvoiceItem.cs
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities
{
    public class InvoiceItem : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        public FeeType FeeType { get; set; }
        
        // Reference to tuition fee (if applicable)
        public Guid? TuitionFeeId { get; set; }
        
        public string? Notes { get; set; }

        // Navigation properties
        public virtual Invoice Invoice { get; set; } = null!;
        public virtual TuitionFee? TuitionFee { get; set; }
    }
}