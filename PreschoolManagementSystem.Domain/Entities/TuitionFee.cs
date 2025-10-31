// Domain/Entities/TuitionFee.cs
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities
{
    public class TuitionFee : BaseEntity
    {
        public Guid ClassroomId { get; set; }
        public FeeType FeeType { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int EffectiveMonth { get; set; }
        public int EffectiveYear { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Additional fees
        public decimal? LatePickupFee { get; set; }
        public decimal? MaterialFee { get; set; }
        public decimal? ActivityFee { get; set; }
        
        public string? Notes { get; set; }

        // Navigation properties
        public virtual Classroom Classroom { get; set; } = null!;
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }

   
}