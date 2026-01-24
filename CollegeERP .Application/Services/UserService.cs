using CollegeERP.Domain.Data.Entities;
using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.DTOs.User;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;


namespace CollegeERP_.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(IUserRepository userRepository,IPasswordHasher<User> passwordHasher)
        {
            _repository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
               var users = await _repository.GetAllAsync();
            return users.Select(user => new UserResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                
                RoleId = user.RoleId
            });
        }
        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            return new UserResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }
        public async Task<UserResponse> CreateAsync(CreateUserRequest userInput)
        {
            if(await _repository.EmailExistsAsync(userInput.Email))
            {
                throw new AlreadyExistsException($"Email {userInput.Email} is already Exists.");
            }
            var user = new User
            {
                Email = userInput.Email,
                RoleId = userInput.RoleId
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, userInput.Password);
            await _repository.AddAsync(user);
            await _repository.SaveAsync();
            return new UserResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                RoleId = user.RoleId
            };

        }
    }
}
