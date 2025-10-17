namespace PreschoolManagementSystem.Domain.Entities;


public class Students
{
    public Guid id { get; set; }
    public string FullName { get; set; }
    public string Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? PlaceOfBirth { get; set; }

    public string? Address { get; set; }
    public string? PhotoUrl { get; set; }

    public string? Allergies { get; set; }

    public string? SpecialDiet { get; set; }
     public string Status { get; set; }
}