using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.DTOs.User;
using CollegeERP_.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeERP_.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService userService)

        {
            _service = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           return Ok(await _service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest userInput)
        {
            var createdUser = await _service.CreateAsync(userInput);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.UserId }, createdUser);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest userInput)
        {
            var updatedUser = await _service.UpdateAsync(id, userInput);
            return Ok(updatedUser);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut("ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordRequest changePasswordRequest)
        {
            await _service.ChangePasswordAsync(id, changePasswordRequest);
            return NoContent();

        }
}
