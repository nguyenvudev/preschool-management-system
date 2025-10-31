// Domain/Entities/ChatSession.cs
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities
{
    public class ChatSession : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public ChatSessionType SessionType { get; set; }
        public Guid? StudentId { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ContextData { get; set; } // JSON data for context

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual StudentStatus? Students { get; set; }
        public virtual ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    }

    public enum ChatSessionType
    {
        Nutrition = 1,
        Health = 2,
        Development = 3,
        General = 4,
        Emergency = 5
    }
}