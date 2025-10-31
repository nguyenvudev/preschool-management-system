using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Domain.Enums;

public class Attendance : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid ClassroomId { get; set; }
        public DateTime Date { get; set; }
        public AttendanceStatus MorningStatus { get; set; } = AttendanceStatus.Present;
        public AttendanceStatus AfternoonStatus { get; set; } = AttendanceStatus.Present;
        public string? AbsenceReason { get; set; }
        public string? Notes { get; set; }
        public Guid RecordedById { get; set; }

        // Navigation properties
        public virtual Students Students { get; set; } = null!;
        public virtual Classroom Classroom { get; set; } = null!;
        public virtual User RecordedBy { get; set; } = null!;
    }
