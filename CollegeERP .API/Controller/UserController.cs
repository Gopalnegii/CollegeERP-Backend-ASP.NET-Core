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
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(v => v.Value.Errors.Count > 0).ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
                throw new ValidationException(errors);
            }
            var createdUser = await _service.CreateAsync(userInput);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.UserId }, createdUser);
        }
    }
}
