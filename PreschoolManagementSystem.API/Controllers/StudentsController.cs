// WebAPI/Controllers/StudentsController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreschoolManagementSystem.Application.Common.Models;
using PreschoolManagementSystem.Application.DTOs.Common;
using PreschoolManagementSystem.Application.DTOs.Health;
using PreschoolManagementSystem.Application.DTOs.Student;
using PreschoolManagementSystem.Application.DTOs.Students;
using PreschoolManagementSystem.Application.Interfaces;

namespace PreschoolManagementSystem.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentService studentService, ILogger<StudentsController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResponse<StudentDto>>>> GetAll(
            [FromQuery] StudentQuery query)
        {
            try
            {
                var result = await _studentService.GetStudentsAsync(query);
                return Ok(ApiResponse<PagedResponse<StudentDto>>.SuccessResult(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get students error");
                return StatusCode(500, ApiResponse<PagedResponse<StudentDto>>.ErrorResult("Lỗi lấy danh sách học sinh"));
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<StudentDetailDto>>> GetById(Guid id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                if (student == null)
                    return NotFound(ApiResponse<StudentDetailDto>.ErrorResult("Không tìm thấy học sinh"));

                return Ok(ApiResponse<StudentDetailDto>.SuccessResult(student));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get student {Id} error", id);
                return StatusCode(500, ApiResponse<StudentDetailDto>.ErrorResult("Lỗi lấy thông tin học sinh"));
            }
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<ApiResponse<StudentDetailDto>>> GetByCode(string code)
        {
            try
            {
                var students = await _studentService.GetStudentsAsync(new StudentQuery { Search = code, PageSize = 1 });
                var student = students.Data.FirstOrDefault();
                
                if (student == null)
                    return NotFound(ApiResponse<StudentDetailDto>.ErrorResult("Không tìm thấy học sinh"));

                var studentDetail = await _studentService.GetStudentByIdAsync(student.Id);
                return Ok(ApiResponse<StudentDetailDto>.SuccessResult(studentDetail!));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get student by code {Code} error", code);
                return StatusCode(500, ApiResponse<StudentDetailDto>.ErrorResult("Lỗi tìm học sinh"));
            }
        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<StudentDto>>> Create(CreateStudentRequest request)
        {
            try
            {
                var student = await _studentService.CreateStudentAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = student.Id }, 
                    ApiResponse<StudentDto>.SuccessResult(student, "Tạo học sinh thành công"));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<StudentDto>.ErrorResult(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create student error");
                return StatusCode(500, ApiResponse<StudentDto>.ErrorResult("Lỗi tạo học sinh"));
            }
        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<StudentDto>>> Update(Guid id, UpdateStudentRequest request)
        {
            try
            {
                if (id != request.Id)
                    return BadRequest(ApiResponse<StudentDto>.ErrorResult("ID không khớp"));

                var student = await _studentService.UpdateStudentAsync(request);
                return Ok(ApiResponse<StudentDto>.SuccessResult(student, "Cập nhật thành công"));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<StudentDto>.ErrorResult(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update student {Id} error", id);
                return StatusCode(500, ApiResponse<StudentDto>.ErrorResult("Lỗi cập nhật học sinh"));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(Guid id)
        {
            try
            {
                await _studentService.DeleteStudentAsync(id);
                return Ok(ApiResponse<object>.SuccessResult(null, "Xóa học sinh thành công"));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ApiResponse<object>.ErrorResult(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete student {Id} error", id);
                return StatusCode(500, ApiResponse<object>.ErrorResult("Lỗi xóa học sinh"));
            }
        }

        [HttpGet("{id:guid}/health-records")]
        public async Task<ActionResult<ApiResponse<List<HealthRecordDto>>>> GetHealthRecords(Guid id)
        {
            try
            {
                var records = await _studentService.GetHealthRecordsAsync(id);
                return Ok(ApiResponse<List<HealthRecordDto>>.SuccessResult(records));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get health records for student {Id} error", id);
                return StatusCode(500, ApiResponse<List<HealthRecordDto>>.ErrorResult("Lỗi lấy lịch sử sức khỏe"));
            }
        }

        [HttpGet("birthdays")]
        public async Task<ActionResult<ApiResponse<List<StudentDto>>>> GetBirthdays()
        {
            try
            {
                var students = await _studentService.GetBirthdayStudentsAsync();
                return Ok(ApiResponse<List<StudentDto>>.SuccessResult(students));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get birthday students error");
                return StatusCode(500, ApiResponse<List<StudentDto>>.ErrorResult("Lỗi lấy danh sách sinh nhật"));
            }
        }

        // [HttpGet("dashboard/stats")]
        // public async Task<ActionResult<ApiResponse<DashboardStatsDto>>> GetDashboardStats()
        // {
        //     try
        //     {
        //         var stats = await _studentService.GetDashboardStatsAsync();
        //         return Ok(ApiResponse<DashboardStatsDto>.SuccessResult(stats));
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex, "Get dashboard stats error");
        //         return StatusCode(500, ApiResponse<DashboardStatsDto>.ErrorResult("Lỗi lấy thống kê"));
        //     }
        // }
    }
}