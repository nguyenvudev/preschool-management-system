using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Students>> GetAllAsync();
        Task<Students?> GetByIdAsync(int id);

        Task<List<Students>> GetByClassroomIdAsync(Guid classroomId);
        Task<List<Students>> GetStudentsWithHealthAlertsAsync();

        Task<Students> AddAsync(Students student);

        Task UpdateAsync(Students student);

        Task DeleteAsync(Guid studentId);
        

    }
}

