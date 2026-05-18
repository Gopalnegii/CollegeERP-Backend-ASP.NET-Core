using CollegeERP.Application.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Application.Interfaces.Services
{
    public interface ICourseService
    {
        Task<GetCourseResponse> GetCourseAsync(int id);
        Task<IEnumerable<GetCourseResponse>> GetAllCoursesAsync();
        Task DeleteCourseAsync(int id);
        Task<GetCourseResponse> UpdateCourseAsync(int id, UpdateCourseRequest request);
        Task<GetCourseResponse> CreateCourseAsync(CreateCourseRequest request);
    }
}
