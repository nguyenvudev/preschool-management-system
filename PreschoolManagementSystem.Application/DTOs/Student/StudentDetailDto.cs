// Application/DTOs/Students/StudentDetailDto.cs
using PreschoolManagementSystem.Application.DTOs.Attendance;
using PreschoolManagementSystem.Application.DTOs.Health;

namespace PreschoolManagementSystem.Application.DTOs.Students
{
    public class StudentDetailDto : StudentDto
    {
        public List<Health.HealthRecordDto> HealthRecords { get; set; } = new();
        public List<AttendanceDto> RecentAttendances { get; set; } = new();
    }
}