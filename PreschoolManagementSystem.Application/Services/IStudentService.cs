// Application/Interfaces/IStudentService.cs
using PreschoolManagementSystem.Application.Common.Models;
// using PreschoolManagementSystem.Application.Dtos;
using PreschoolManagementSystem.Application.DTOs.Common;
// using PreschoolManagementSystem.Application.DTOs.Dashboard;
using PreschoolManagementSystem.Application.DTOs.Health;
using PreschoolManagementSystem.Application.DTOs.Student;
using PreschoolManagementSystem.Application.DTOs.Students;

namespace PreschoolManagementSystem.Application.Interfaces
{
    public interface IStudentService
    {
        Task<PagedResponse<StudentDto>> GetStudentsAsync(StudentQuery query);
        Task<StudentDetailDto?> GetStudentByIdAsync(Guid id);
        Task<StudentDto> CreateStudentAsync(CreateStudentRequest request);
        Task<StudentDto> UpdateStudentAsync(UpdateStudentRequest request);
        Task DeleteStudentAsync(Guid id);
        Task<List<HealthRecordDto>> GetHealthRecordsAsync(Guid studentId);
        // Task<DashboardStatsDto> GetDashboardStatsAsync();
        Task<List<StudentDto>> GetBirthdayStudentsAsync();
    }

    public class StudentQuery : PaginationQuery
    {
        public Guid? ClassroomId { get; set; }
        public string? Status { get; set; }
        public string? Gender { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}