// Application/DTOs/Auth/Requests/ChangePasswordRequest.cs
using System.ComponentModel.DataAnnotations;

namespace PreschoolManagementSystem.Application.DTOs.Auth.Requests
{
    public class ChangePasswordRequest
    {
        public Guid UserId { get; set; }
        
        [Required(ErrorMessage = "Mật khẩu hiện tại là bắt buộc")]
        public string CurrentPassword { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Mật khẩu mới là bắt buộc")]
        [MinLength(6, ErrorMessage = "Mật khẩu mới phải có ít nhất 6 ký tự")]
        public string NewPassword { get; set; } = string.Empty;
        
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}