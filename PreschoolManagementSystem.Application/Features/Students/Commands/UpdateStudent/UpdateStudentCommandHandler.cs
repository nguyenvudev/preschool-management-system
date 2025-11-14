
using AutoMapper;
using MediatR;
using PreschoolManagementSystem.Application.Common.Models;
using PreschoolManagementSystem.Application.DTOs.Students;
using PreschoolManagementSystem.Application.Interfaces;

namespace PreschoolManagementSystem.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, ApiResponse<StudentDto>>
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<StudentDto>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var student = await _studentRepository.GetByIdAsync(request.StudentId);
                if (student == null)
                {
                    return ApiResponse<StudentDto>.ErrorResult("Không tìm thấy học sinh");
                }
                if (!student.Code.Equals(request.Code, StringComparison.OrdinalIgnoreCase))
                {

                    var existingStudent = await _studentRepository.GetAllAsync();
                    if (existingStudent != null)
                    {
                        return ApiResponse<StudentDto>.ErrorResult("Mã học sinh đã tồn tại");
                    }
                }
                _mapper.Map(request, student);
                student.UpdatedAt = DateTime.Now;
                await _studentRepository.UpdateAsync(student);

                return ApiResponse<StudentDto>.SuccessResult(_mapper.Map<StudentDto>(student), "Cập nhật thành công");

            }

            catch (Exception ex)
            {
                return ApiResponse<StudentDto>.ErrorResult($"Lỗi cập nhật học sinh: {ex.Message}");
            }
        }
    }
}