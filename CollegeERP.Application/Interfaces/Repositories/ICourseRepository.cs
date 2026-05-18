using CollegeERP.Domain.Data.Entities;

namespace CollegeERP.Application.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task<Course?> GetCourseByIdAsync(int CorId);
        Task<IEnumerable<Course>> GetAllCourseAsync();
        Task<Course> CreateCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
    }
}
