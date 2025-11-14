
using MediatR;
using PreschoolManagementSystem.Application.Common.Models;
using PreschoolManagementSystem.Application.DTOs.Students;

namespace PreschoolManagementSystem.Application.Features.Students.Commands.UpdateStudent
{
    public sealed record UpdateStudentCommand : IRequest<ApiResponse<StudentDto>>
    {
        public Guid StudentId { get; init; }
        public string Code { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public DateTime DateOfBirth { get; init; }
        public string Gender { get; init; } = string.Empty;
        public string? AvatarUrl { get; init; }
        public string? ParentName { get; init; }
        public string? ParentPhone { get; init; }
        public string? ParentEmail { get; init; }
        public string? Address { get; init; }
        public string? BloodType { get; init; }
        public string? Allergies { get; init; }
        public string? MedicalConditions { get; init; }
        public string? EmergencyContact { get; init; }
        public string? EmergencyPhone { get; init; }
        public Guid? ClassroomId { get; init; }
    }


}