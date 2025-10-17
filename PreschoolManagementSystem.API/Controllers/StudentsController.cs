

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PreschoolManagementSystem.Application.Dtos;
using PreschoolManagementSystem.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentsController(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
      [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _studentRepository.GetAllAsync();
        var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
        return Ok(studentDtos);
    }
}
