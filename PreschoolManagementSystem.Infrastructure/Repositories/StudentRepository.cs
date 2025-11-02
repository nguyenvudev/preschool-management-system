using Microsoft.EntityFrameworkCore;
using PreschoolManagementSystem.Application.Interfaces;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Infrastructure.Data;

namespace PreschoolManagementSystem.Infrastructure.Repository;

public class StudentRepository : IStudentRepository
{

    private readonly PreschoolDbContext _context;

    public StudentRepository(PreschoolDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Students>> GetAllAsync()
    {
        return await _context.students.ToListAsync();
    }

    public async Task<Students?> GetByIdAsync(Guid id)
    {
        return await _context.students.FindAsync(id);
    }
    public async Task<Students> AddAsync(Students student)
    {
        await _context.students.AddAsync(student);
        await _context.SaveChangesAsync();
        return student;
    }
    public async Task UpdateAsync(Students student)
    {
        _context.students.Update(student);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Guid studentId)
    {
        var student = await _context.students.FindAsync(studentId);
        if (student != null)
        {
            _context.students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Students>> GetByClassroomIdAsync(Guid classroomId)
    {
        return await _context.students
            .Where(s => s.ClassroomId == classroomId)
            .ToListAsync();
    }
        public async Task<List<Students>> GetStudentsWithHealthAlertsAsync()
        {
            return await _context.students
                .Where(s => s.MedicalConditions != null && s.MedicalConditions != "")
                .ToListAsync();
        }

  
}