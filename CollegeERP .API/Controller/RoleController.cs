using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.DTOs.Role;
using CollegeERP_.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeERP_.API.Controller
{
    [Authorize(Roles = "Admin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            return Ok(role);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleCreateRequest request)
        {
            var createdRole = await _roleService.CreateAsync(request);
            return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.RoleId }, createdRole);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleUpdateRequest request)
        {
            var updatedRole = await _roleService.UpdateAsync(id, request);
            return Ok(updatedRole);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteAsync(id);
            return NoContent();
        }
    }
}