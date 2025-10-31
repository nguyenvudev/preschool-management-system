namespace PreschoolManagementSystem.Application.DTOs.Attendance
{
    public class AttendanceDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public Guid ClassroomId { get; set; }
        public string ClassroomName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string MorningStatus { get; set; } = string.Empty;
        public string AfternoonStatus { get; set; } = string.Empty;
        public string? AbsenceReason { get; set; }
        public string? Notes { get; set; }
        public string RecordedByName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}