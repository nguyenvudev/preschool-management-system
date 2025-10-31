namespace PreschoolManagementSystem.Application.DTOs.Health
{
    public class CreateHealthRecordRequest
    {
        public Guid StudentId { get; set; }
        public DateTime RecordDate { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal? Temperature { get; set; }
        public string HealthStatus { get; set; } = string.Empty;
        public string? Symptoms { get; set; }
        public string? Medications { get; set; }
        public string? DoctorNotes { get; set; }
    }
}
