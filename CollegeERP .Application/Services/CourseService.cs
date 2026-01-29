using CollegeERP.Domain.Data.Entities;
using CollegeERP_.Application.DTOs.Courses;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Application.Interfaces.Services;

namespace CollegeERP_.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository) 
        {
            _courseRepository = courseRepository;
        }
        public async Task<GetCourseResponse> GetCourseAsync(int id)
        {
             var repoResponse = await _courseRepository.GetCourseByIdAsync(id);
            if (repoResponse == null)
            {
                throw new KeyNotFoundException("Course Not Found");
            }
            var Course = new GetCourseResponse {
                CourseId = repoResponse.CourseId,
                CourseName = repoResponse.CourseName,
                DepartmentId = repoResponse.DepartmentId,
                TotalSemesters = repoResponse.TotalSemesters,
            };
            return Course;
        }
        public async Task<IEnumerable<GetCourseResponse>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllCourseAsync();
            return courses.Select(c=> new GetCourseResponse {
                CourseId = c.CourseId,
                DepartmentId= c.DepartmentId,
                CourseName=c.CourseName,
                TotalSemesters = c.TotalSemesters
            });
        }
        public async Task DeleteCourseAsync(int id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null)
            {
                throw new KeyNotFoundException("Course not Found");
            }
            course.Status = 0;
            await _courseRepository.UpdateCourseAsync(course);
        }

        public async Task<GetCourseResponse> UpdateCourseAsync(int id, UpdateCourseRequest request)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null)
            {
                throw new KeyNotFoundException("Course not found.");
            }
            course.TotalSemesters = request.TotalSemesters;
            course.CourseName = request.CourseName;
            course.DepartmentId = request.DepartmentId;
            await _courseRepository.UpdateCourseAsync(course);
            return new GetCourseResponse
            {
                CourseId = course.CourseId,
                DepartmentId = course.DepartmentId,
                CourseName = course.CourseName,
                TotalSemesters = course.TotalSemesters
            };
        }
        public async Task<GetCourseResponse> CreateCourseAsync(CreateCourseRequest request)
        {
            var serviceRequest = new Course
            {
                TotalSemesters= request.TotalSemesters,
                DepartmentId= request.DepartmentId,
                CourseName= request.CourseName,
            };
            var repositoryResponse = await _courseRepository.CreateCourseAsync(serviceRequest);
            var serviceResponse = new GetCourseResponse
            {
                CourseId= repositoryResponse.CourseId,
                CourseName= repositoryResponse.CourseName,
                DepartmentId= repositoryResponse.DepartmentId,
                TotalSemesters= repositoryResponse.TotalSemesters
            };
            return serviceResponse;
        }

    }
}
