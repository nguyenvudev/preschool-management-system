using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Application.Interfaces
{
    public interface IWeeklyScheduleRepository
    {
        Task<IEnumerable<WeeklySchedule>> GetByClassroomIdAsync(Guid classroomId);

        Task<IEnumerable<WeeklySchedule>> GetTeacherIdAsync(Guid teacherId);
        Task<WeeklySchedule?> GetByIdAsync(Guid id);

        Task<WeeklySchedule> AddAsync(WeeklySchedule schedule);

        Task UpdateAsync(WeeklySchedule schedule);

        Task DeleteAsync(Guid scheduleId);

        Task DeleteByClassroomIdAsync(Guid classroomId);
        
    }
}