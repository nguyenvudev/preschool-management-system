namespace PreschoolManagementSystem.Application.Features.Students.Commands.CreateStudent
{
    using MediatR;
    using PreschoolManagementSystem.Application.Common.Models;
    using PreschoolManagementSystem.Application.DTOs.Students;
    using PreschoolManagementSystem.Application.Interfaces;
    using PreschoolManagementSystem.Domain.Entities;
    using AutoMapper;

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, ApiResponse<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<StudentDto>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Students>(request);
            student.Id = Guid.NewGuid();

            await _studentRepository.AddAsync(student);

            var studentDto = _mapper.Map<StudentDto>(student);
            return ApiResponse<StudentDto>.SuccessResult(studentDto, "Học sinh được tạo thành công");
        }
    }
}