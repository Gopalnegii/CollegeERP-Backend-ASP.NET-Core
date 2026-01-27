using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.DTOs.User;
using CollegeERP_.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CollegeERP_.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService userService)

        {
            _service = userService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet("me")]
        public async Task<IActionResult> GetById(int id)
        {
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claimId == null)
            {
                throw new UnauthorizedAccessException("Invalid Token");
            }
            return Ok(await _service.GetByIdAsync(int.Parse(claimId.Value)));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdForAdmin(int id)
        {
            
            return Ok(await _service.GetByIdAsync(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest userInput)
        {
            var createdUser = await _service.CreateAsync(userInput);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.UserId }, createdUser);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForAdmin(int id, [FromBody] UpdateUserRequest userInput)
        {
            var updatedUser = await _service.UpdateAsync(id, userInput);
            return Ok(updatedUser);
        }
        [HttpPut("me")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest userInput)
        {
            var userid=User.FindFirst(ClaimTypes.NameIdentifier);
            if(userid==null)
            {
                throw new UnauthorizedAccessException("Invalid Token");
            }
           var id = int.Parse(userid.Value);
            var updatedUser = await _service.UpdateAsync(id, userInput);
            return Ok(updatedUser);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim == null)
            {
                throw new UnauthorizedAccessException("Invalid Token");
            }
            int id = int.Parse(idClaim.Value);
            await _service.ChangePasswordAsync(id, changePasswordRequest);
            return NoContent();

        }
    }
}
