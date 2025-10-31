using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities;

public class HealthRecord : BaseEntity
{
    public Guid StudentId { get; set; }
    public DateTime RecordDate { get; set; }

    // Physical measurements
    public decimal Height { get; set; } // cm
    public decimal Weight { get; set; } // kg
    public decimal BMI { get; set; }
    public decimal? Temperature { get; set; }
    public string? BloodPressure { get; set; }
    public decimal? HeadCircumference { get; set; } // Chu vi vòng đầu


    // Health status
    public HealthStatus HealthStatus { get; set; }
    public string? Symptoms { get; set; }
    public string? Medications { get; set; }
    public string? DoctorNotes { get; set; }
    public string? Recommendations { get; set; }


    public bool VaccinationUpToDate { get; set; } = true;
    public string? VaccinationNotes { get; set; }

    public Guid RecordedById { get; set; }

    // Navigation properties
    public virtual Students Students { get; set; } = null!;
    public virtual User RecordedBy { get; set; } = null!;
        
    
        
}