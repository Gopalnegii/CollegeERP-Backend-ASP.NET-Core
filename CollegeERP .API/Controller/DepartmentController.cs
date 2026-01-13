using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.DTOs;
using CollegeERP_.Application.Interfaces.Services;
using CollegeERP_.Application.Services.Departments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDTO departmentDto)
        {
            try
            {
                var createdDepartment =
                await _DepartmentService.CreateDepartmentAsync(departmentDto);

                return CreatedAtAction(
                    nameof(GetDepartmentById),
                    new { id = createdDepartment.DepartmentId },
                    createdDepartment
                );
            }
            catch (DepartmentAlreadyExistsException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequest requestDTO)
        {
            try
            {
                var updatedDepartment =
                     await _DepartmentService.UpdateDepartmentAsync(requestDTO);
                return Ok(updatedDepartment);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (DepartmentAlreadyExistsException ex)
            {
                return Conflict(new { message = ex.Message });
            }

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
                return NotFound(new {message = "Department not found"});
            }
            return Ok(department);
        }
}
}
