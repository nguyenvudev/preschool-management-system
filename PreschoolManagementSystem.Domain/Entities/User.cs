using System.ComponentModel.DataAnnotations;
using PreschoolManagementSystem.Domain.Enums;

    namespace PreschoolManagementSystem.Domain.Entities
    {

        public class User : BaseEntity
          {
            [Required(ErrorMessage = "email is required")]
            [EmailAddress(ErrorMessage = "Invalid email format")]
            [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
            public string Email { get; set; } = string.Empty;
            [Required(ErrorMessage = "PasswordHash is required")]
            public string PasswordHash { get; set; } = string.Empty;
        [Required(ErrorMessage = "FullName is required")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Họ tên phải từ 2 đến 255 ký tự")]
            public string FullName { get; set; } = string.Empty;
            public UserRole Role { get; set; } 
            public string? PhoneNumber { get; set; }
            public string? AvatarUrl { get; set; }
            public bool IsActive { get; set; } = true;
            public Guid PreschoolId { get; set; }

            // Navigation

        
            public string? RefreshToken { get; set; }
            public DateTime? RefreshTokenExpiryTime { get; set; }


            
            public ICollection<RefreshToken> RefreshTokens { get; set; }
            public ICollection<AuditLog> AuditLogs { get; set; }
        }
    }
