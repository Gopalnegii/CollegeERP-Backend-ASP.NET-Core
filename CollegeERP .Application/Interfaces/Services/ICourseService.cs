using CollegeERP_.Application.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Interfaces.Services
{
    public interface ICourseService
    {
        Task<GetCourseResponse> GetCourseAsync(int id);
        Task<IEnumerable<GetCourseResponse>> GetAllCoursesAsync();
        Task DeleteCourseAsync(int id);
        Task<GetCourseResponse> UpdateCourseAsync(UpdateCourseRequest request);
        Task<GetCourseResponse> CreateCourseAsync(CreateCourseRequest request);
    }
}
