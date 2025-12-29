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
    }
}
