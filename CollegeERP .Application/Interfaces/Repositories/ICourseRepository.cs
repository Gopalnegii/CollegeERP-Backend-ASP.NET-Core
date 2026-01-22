using CollegeERP.Domain.Data.Entities;

namespace CollegeERP_.Application.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByIdAsync(int CorId);
        Task<IEnumerable<Course>> GetAllCourseAsync();
        Task DeleteCourseAsync(int CourseId);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(Course course);
    }
}
