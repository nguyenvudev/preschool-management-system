namespace PreschoolManagementSystem.Application.DTOs.Attendance
{
    public class CreateAttendanceRequest

    {
        public Guid StudentId { get; set; }
        public Guid ClassroomId { get; set; }
        public DateTime Date { get; set; }
        public string MorningStatus { get; set; } = string.Empty;
        public string AfternoonStatus { get; set; } = string.Empty;
        public string? AbsenceReason { get; set; }
        public string? Notes { get; set; }
    }
}