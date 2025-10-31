// Domain/Entities/Notification.cs
using System.Collections.Generic;
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public NotificationPriority Priority { get; set; } = NotificationPriority.Medium;
        
        // Target audience
        public UserRole? TargetRole { get; set; }
        public Guid? TargetUserId { get; set; }
        public Guid? TargetClassroomId { get; set; }
        public Guid? TargetStudentId { get; set; }
        
        // Delivery status
        public bool IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        
        // Actions
        public string? ActionUrl { get; set; }
        public string? ActionText { get; set; }
        
        public Guid CreatedById { get; set; }

        // Navigation properties
        public virtual User CreatedBy { get; set; } = null!;
        public virtual Classroom? TargetClassroom { get; set; }
        public virtual Students? TargetStudent { get; set; }
        public virtual ICollection<NotificationReceipt> Receipts { get; set; } = new List<NotificationReceipt>();
    }



}