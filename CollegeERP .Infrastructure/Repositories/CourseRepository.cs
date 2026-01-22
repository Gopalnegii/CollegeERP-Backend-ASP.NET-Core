using CollegeERP.Domain.Data.Entities;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CollegeERP_.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CollegeERPDbContext _context;
        public CourseRepository(CollegeERPDbContext context )
        {
            _context = context;
        }
        public async Task<Course> GetCourseByIdAsync(int courseId) 
        {
            var course = await _context.Courses.Where(c=>c.CourseId == courseId && c.Status !=0).FirstOrDefaultAsync();
            if (course == null)
            {
                throw new KeyNotFoundException("Course not found");
            }
            return course;
        }
        public async Task<IEnumerable<Course>> GetAllCourseAsync()
        {
            var courses = await _context.Courses.Where(c =>c.Status != 0).ToListAsync(); 
            return courses;
        }
        public async Task<Course> UpdateCourseAsync(Course course)
        {
            var existing = await _context.Courses.FirstOrDefaultAsync(c=> c.CourseId == course.CourseId && c.Status != 0);
            if (existing == null)
            {
                throw new KeyNotFoundException("Course not found");
            }
            existing.CourseName = course.CourseName;
            existing.TotalSemesters = course.TotalSemesters;
            existing.DepartmentId = course.DepartmentId;
                await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<Course> CreateCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
                return course;
        }

        public async Task DeleteCourseAsync(int CourseId)
        {
            var course =await _context.Courses.FindAsync(CourseId);
            if(course==null || course.Status ==0)
            {
                throw new KeyNotFoundException("Course Not Found");
            }
            course.Status = 0;
            await _context.SaveChangesAsync();

        }
      
    }
}
