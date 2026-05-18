using CollegeERP.Domain.Data.Entities;
using CollegeERP.Application.Interfaces.Repositories;
using CollegeERP.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CollegeERP.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CollegeERPDbContext _context;
        public CourseRepository(CollegeERPDbContext context )
        {
            _context = context;
        }
        public async Task<Course?> GetCourseByIdAsync(int courseId) 
        {
            var course = await _context.Courses.Where(c=>c.CourseId == courseId && c.Status !=0).FirstOrDefaultAsync();
            
            return course;
        }
        public async Task<IEnumerable<Course>> GetAllCourseAsync()
        {
            var courses = await _context.Courses.Where(c =>c.Status != 0).ToListAsync(); 
            return courses;
        }
        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
        public async Task<Course> CreateCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }
      
    }
}
