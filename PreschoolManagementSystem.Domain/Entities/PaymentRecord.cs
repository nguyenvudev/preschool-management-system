// Domain/Entities/PaymentRecord.cs
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities
{
    public class PaymentRecord : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? TransactionId { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
        public Guid ReceivedById { get; set; }
        
        // For bank transfers
        public string? BankName { get; set; }
        public string? AccountNumber { get; set; }
        public DateTime? TransferDate { get; set; }

        // Navigation properties
        public virtual Invoice Invoice { get; set; } = null!;
        public virtual User ReceivedBy { get; set; } = null!;
    }
}