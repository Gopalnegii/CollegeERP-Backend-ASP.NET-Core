using CollegeERP.Domain.Exceptions;
using CollegeERP.Application.DTOs.Department;
using CollegeERP.Application.Interfaces.Services;
using CollegeERP.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeERP.API.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _DepartmentService = departmentService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDTO departmentDto)
        {
            var createdDepartment =
            await _DepartmentService.CreateDepartmentAsync(departmentDto);

            return CreatedAtAction(
                nameof(GetDepartmentById),
                new { id = createdDepartment.DepartmentId },
                createdDepartment
            );
        }
        [Authorize(Roles = "Admin")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentRequest requestDTO)
        {
            var updatedDepartment = await _DepartmentService.UpdateDepartmentAsync(id,requestDTO);
            return Ok(updatedDepartment);
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _DepartmentService.DeleteDepartment(id);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        { 
            var departments = await _DepartmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _DepartmentService.GetDepartmentByIdAsync(id);
            return Ok(department);
        }
    }
}
