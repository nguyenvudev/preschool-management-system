namespace  PreschoolManagementSystem.Application.DTOs.ClassRoom;
using System.ComponentModel.DataAnnotations;

public class CreateClassroomRequest
    {
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

        [Required(ErrorMessage = "Năm học là bắt buộc")]
        [Range(2020, 2030, ErrorMessage = "Năm học phải từ 2020 đến 2030")]
        public int AcademicYear { get; set; }

        [Required(ErrorMessage = "Học kỳ là bắt buộc")]
        [Range(1, 2, ErrorMessage = "Học kỳ phải là 1 hoặc 2")]
        public int Semester { get; set; }

        public Guid? HeadTeacherId { get; set; }
        public Guid? AssistantTeacherId { get; set; }
    }