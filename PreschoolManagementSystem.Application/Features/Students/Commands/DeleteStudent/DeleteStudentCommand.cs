// Application/Features/Students/Commands/DeleteStudent/DeleteStudentCommand.cs
using MediatR;
using PreschoolManagementSystem.Application.Common.Models;

namespace PreschoolManagementSystem.Application.Features.Students.Commands.DeleteStudent
{
    public sealed record DeleteStudentCommand : IRequest<ApiResponse<object>>
    {
        public Guid StudentId { get; init; }
    }
}