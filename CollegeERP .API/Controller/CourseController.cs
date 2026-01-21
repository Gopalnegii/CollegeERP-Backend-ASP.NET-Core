using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.DTOs.Courses;
using CollegeERP_.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeERP_.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseServices;
        public CourseController(ICourseService courseServices)
        {
            _courseServices = courseServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            return Ok(await _courseServices.GetAllCoursesAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseByIdAsync(int id)
        {
            return Ok(await _courseServices.GetCourseAsync(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            await _courseServices.DeleteCourseAsync(id);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourseAsync([FromBody] CreateCourseRequest createCourseRequest)
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Where(c => c.Value.Errors.Count > 0).ToDictionary(
                    c => c.Key,
                    c => c.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                throw new ValidationException(errors);
            }
            var serviceResponse = await _courseServices.CreateCourseAsync(createCourseRequest);
            return CreatedAtAction(nameof(GetCourseByIdAsync),
                new { id = serviceResponse.CourseId },
                serviceResponse);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourseAsync([FromBody] UpdateCourseRequest updateCourseRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(c => c.Value.Errors.Count > 0).ToDictionary(
                    c => c.Key,
                    c => c.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                throw new ValidationException(errors);
            }
            var updateServiceResponse = await _courseServices.UpdateCourseAsync(updateCourseRequest);
            return Ok(updateServiceResponse);
        }

    }
}

