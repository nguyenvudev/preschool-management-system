using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Application.Interfaces
{
    public interface IWeeklyActivityRepository
    {
        Task<IEnumerable<WeeklyActivity>> GetByScheduleIdAsync(Guid scheduleId);

        Task<IEnumerable<WeeklyActivity>> GetByClassroomIdAsync(Guid classroomId);

        Task<IEnumerable<WeeklyActivity>> GetByTeacherIdAsync(Guid teacherId);

        Task<IEnumerable<WeeklyActivity>> GetUpcomingActivitiesAsync(Guid classroomId, DateTime fromDate);


        Task<WeeklyActivity?> GetByIdAsync(Guid id);

        Task<WeeklyActivity> AddAsync(WeeklyActivity activity);

        Task UpdateAsync(WeeklyActivity activity);

        Task DeleteAsync(Guid activityId);

        Task DeleteByScheduleIdAsync(Guid scheduleId);
    }
}