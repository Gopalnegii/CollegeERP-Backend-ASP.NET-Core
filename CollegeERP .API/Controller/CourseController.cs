using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.DTOs.Courses;
using CollegeERP_.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeERP_.API.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/Course")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseServices;
        public CourseController(ICourseService courseServices)
        {
            _courseServices = courseServices;
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            return Ok(await _courseServices.GetAllCoursesAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            return Ok(await _courseServices.GetCourseAsync(id));
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseServices.DeleteCourseAsync(id);
            return NoContent();
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest createCourseRequest)
        { 
            var serviceResponse = await _courseServices.CreateCourseAsync(createCourseRequest);
            return CreatedAtAction(nameof(GetCourseById),
                new { id = serviceResponse.CourseId },
                serviceResponse);
        }
        [Authorize(Roles ="Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseRequest updateCourseRequest)
        {
            var updateServiceResponse = await _courseServices.UpdateCourseAsync(updateCourseRequest);
            return Ok(updateServiceResponse);
        }

    }
}

