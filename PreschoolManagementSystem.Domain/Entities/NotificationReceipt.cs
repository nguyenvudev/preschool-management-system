using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities
{
    public class NotificationReceipt : BaseEntity
    {
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public bool IsAcknowledged { get; set; }
        public DateTime? AcknowledgedAt { get; set; }

        // Navigation properties
        public virtual Notification Notification { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}