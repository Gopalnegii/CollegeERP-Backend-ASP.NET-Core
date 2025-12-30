using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CollegeERP_.Application.Interfaces.Services;

namespace CollegeERP_.API.Controller
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _DepartmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _DepartmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _DepartmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound(new {message = " Department not found"});
            }
            return Ok(department);
    }
}
}
