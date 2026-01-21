using CollegeERP.Domain.Data.Entities;
using CollegeERP_.Application.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Text;

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
