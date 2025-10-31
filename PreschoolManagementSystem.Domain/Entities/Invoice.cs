// Domain/Entities/Invoice.cs
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public Guid StudentId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        
        // Amount details
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal LateFee { get; set; }
        public decimal GrandTotal => TotalAmount - DiscountAmount + TaxAmount + LateFee;
        public decimal BalanceDue => GrandTotal - PaidAmount;
        
        // Status
        public InvoiceStatus Status { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? TransactionId { get; set; }
        
        // Notes
        public string? Notes { get; set; }
        public string? PaymentNotes { get; set; }
        
        public Guid CreatedById { get; set; }

        // Navigation properties
        public virtual Students Student { get; set; } = null!;
        public virtual User CreatedBy { get; set; } = null!;
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
        public virtual ICollection<PaymentRecord> PaymentRecords { get; set; } = new List<PaymentRecord>();
    }

}