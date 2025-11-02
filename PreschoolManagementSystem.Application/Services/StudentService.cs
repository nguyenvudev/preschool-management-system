using AutoMapper;
using PreschoolManagementSystem.Application.DTOs.Common;
using PreschoolManagementSystem.Application.DTOs.Health;
using PreschoolManagementSystem.Application.DTOs.Student;
using PreschoolManagementSystem.Application.DTOs.Students;
using PreschoolManagementSystem.Application.Interfaces;
using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<StudentDto>> GetStudentsAsync(StudentQuery query)
        {
            var allStudents = await _studentRepository.GetAllAsync();

            var list = _mapper.Map<List<StudentDto>>(allStudents);

            return new PagedResponse<StudentDto>
            {
                Data = list,
                TotalCount = list.Count,
                Page = 1,
                PageSize = list.Count
            };
        }

        public async Task<StudentDetailDto?> GetStudentByIdAsync(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDetailDto>(student);
        }

        public async Task<StudentDto> CreateStudentAsync(CreateStudentRequest request)
        {
            var student = _mapper.Map<Students>(request);
            student.Id = Guid.NewGuid();

            await _studentRepository.AddAsync(student);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> UpdateStudentAsync(UpdateStudentRequest request)
        {
            var student = await _studentRepository.GetByIdAsync(request.Id);
            if (student == null)
                throw new ArgumentException("Không tìm thấy học sinh");

            _mapper.Map(request, student);
            await _studentRepository.UpdateAsync(student);

            return _mapper.Map<StudentDto>(student);
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        public async Task<List<HealthRecordDto>> GetHealthRecordsAsync(Guid studentId)
        {
            return new List<HealthRecordDto>();
        }

        public async Task<List<StudentDto>> GetBirthdayStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            var today = DateTime.Now;

            var filtered = students
                .Where(s => s.DateOfBirth.Month == today.Month && s.DateOfBirth.Day == today.Day);

            return _mapper.Map<List<StudentDto>>(filtered);
        }
    }
}
