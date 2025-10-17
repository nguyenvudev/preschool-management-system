using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Students>> GetAllAsync();
        Task<Students?> GetByIdAsync(int id);
        Task Create(Students student);
    }
}