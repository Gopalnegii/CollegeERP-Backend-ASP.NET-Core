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
            return courses.Select(c=> new GetCourseResponse { CourseId = c.CourseId,DepartmentId= c.DepartmentId,CourseName=c.CourseName,TotalSemesters = c.TotalSemesters});
        }
        public async Task DeleteCourseAsync(int id)
        {
            await _courseRepository.DeleteCourseAsync(id);
        }
        public async Task<GetCourseResponse> UpdateCourseAsync(UpdateCourseRequest request)
        {
            var course = new Course { CourseId= request.CourseId ,CourseName=request.CourseName, DepartmentId=request.DepartmentId,TotalSemesters=request.TotalSemesters };
            var responseCourse = await _courseRepository.UpdateCourseAsync(course);
            var serviceCourseResponse = new GetCourseResponse
            {
                CourseId = responseCourse.CourseId,
                CourseName = responseCourse.CourseName,
                DepartmentId = responseCourse.DepartmentId,
                TotalSemesters = responseCourse.TotalSemesters
            };
            return serviceCourseResponse;
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
