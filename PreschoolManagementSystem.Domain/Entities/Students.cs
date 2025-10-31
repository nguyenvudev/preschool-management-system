using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Domain.Entities;


public class Students : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string FullName { get; set; }
    public string Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? PlaceOfBirth { get; set; }

    public string? Address { get; set; }
    public string? PhotoUrl { get; set; }

    public string? ParentName { get; set; }
    public string? ParentPhone { get; set; }
    public string? ParentEmail { get; set; }
    // Medical information
    public string? BloodType { get; set; }
    public string? Allergies { get; set; }
    public string? MedicalConditions { get; set; }
    public string? EmergencyContact { get; set; }
    public string? EmergencyPhone { get; set; }
    public Guid? ClassroomId { get; set; }
    public StudentStatus Status { get; set; } = StudentStatus.Active;



    // Navigation properties
 
                public virtual Classroom? Classroom { get; set; }

        // public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    // public virtual ICollection<HealthRecord> HealthRecords { get; set; } = new List<HealthRecord>();
    // public virtual ICollection<NutritionRecord> NutritionRecords { get; set; } = new List<NutritionRecord>();
}

