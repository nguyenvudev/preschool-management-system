namespace  PreschoolManagementSystem.Application.DTOs.ClassRoom;

using System.ComponentModel.DataAnnotations;

public class UpdateClassroomRequest
    {
        [Required(ErrorMessage = "ID lớp học là bắt buộc")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tên lớp học là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên lớp học không quá 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cấp độ lớp là bắt buộc")]
        public string GradeLevel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sức chứa là bắt buộc")]
        [Range(1, 50, ErrorMessage = "Sức chứa phải từ 1 đến 50 học sinh")]
        public int Capacity { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không quá 500 ký tự")]
        public string? Description { get; set; }

        [StringLength(50, ErrorMessage = "Vị trí phòng không quá 50 ký tự")]
        public string? RoomLocation { get; set; }

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        public bool IsActive { get; set; }
    }