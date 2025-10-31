// Application/DTOs/Dashboard/DashboardStatsDto.cs
namespace PreschoolManagementSystem.Application.DTOs.Dashboard
{
    public class DashboardStatsDto
    {
        public int TotalStudents { get; set; }
        public int TotalClassrooms { get; set; }
        public int TotalTeachers { get; set; }
        public decimal AttendanceRate { get; set; }
        public int HealthAlerts { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public int NewStudentsThisMonth { get; set; }
        public int AbsentToday { get; set; }
    }
}