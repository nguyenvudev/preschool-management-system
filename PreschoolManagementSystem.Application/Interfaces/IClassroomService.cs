using PreschoolManagementSystem.Application.DTOs.Students;

namespace PreschoolManagementSystem.Application.Interfaces
{
    public interface IClassroomService
    {
        Task<IEnumerable<Classroom>> GetClassroomsAsync();
        Task<Classroom?> GetClassroomByIdAsync(Guid id);

        Task<Classroom?> GetIdWithDetailsAsync(Guid id);


        Task<Classroom> addAsync(Classroom classroom);

        Task updateAsync(Classroom classroom);

        Task deleteAsync(Guid classroomId);

        Task<IEnumerable<Classroom>> GetByTeacherIdAsync(Guid teacherId);

        Task<IEnumerable<Classroom>> GetActiveClassroomsAsync();

        Task<bool> ClassroomExistsAsync(Guid classroomId);

        Task<int> GetStudentCountAsync(Guid classroomId);
        



    }
 }