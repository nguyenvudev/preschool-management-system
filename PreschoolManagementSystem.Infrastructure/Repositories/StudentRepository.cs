// using Microsoft.EntityFrameworkCore;
// using PreschoolManagementSystem.Application.Interfaces;
// using PreschoolManagementSystem.Domain.Entities;
// using PreschoolManagementSystem.Infrastructure.Data;

// namespace PreschoolManagementSystem.Infrastructure.Repository;

// public class StudentRepository : IStudentRepository
// {

//     private readonly PreschoolDbContext _context;

//     public StudentRepository(PreschoolDbContext context)
//     {
//         _context = context;
//     }
//     public async Task<IEnumerable<Students>> GetAllAsync() =>
//           await _context.Students.ToListAsync();



//     public async Task<Students?> GetByIdAsync(int id) =>
//        await _context.Students.FindAsync(id);
        
//          public async Task Create(Students student)
//     {
//         await _context.Students.AddAsync(student);
//         await _context.SaveChangesAsync();
//     }
// }