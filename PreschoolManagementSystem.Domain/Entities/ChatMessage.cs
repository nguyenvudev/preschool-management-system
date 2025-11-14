// Domain/Entities/ChatMessage.cs
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities;

    public class ChatMessage : BaseEntity
    {
        public Guid SessionId { get; set; }
        public string Content { get; set; } = string.Empty;
        public MessageRole Role { get; set; }
        public MessageType MessageType { get; set; } = MessageType.Text;
        
        // For AI responses
        public string? Suggestions { get; set; } // JSON array
        public string? QuickReplies { get; set; } // JSON array
        public string? Metadata { get; set; } // JSON data
        
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }

        // Navigation properties
        public virtual ChatSession Session { get; set; } = null!;
    }

