// Domain/Entities/RefreshToken.cs
namespace PreschoolManagementSystem.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public string? ReplacedByToken { get; set; }
        public string? RevocationReason { get; set; }
        public bool IsActive => RevokedAt == null && DateTime.UtcNow <= ExpiresAt;

        // Navigation properties
        public virtual User User { get; set; } = null!;
    }
    
}