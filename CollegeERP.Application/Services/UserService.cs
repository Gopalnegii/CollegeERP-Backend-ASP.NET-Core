using CollegeERP.Domain.Data.Entities;
using CollegeERP.Domain.Exceptions;
using CollegeERP.Application.DTOs.User;
using CollegeERP.Application.Interfaces.Repositories;
using CollegeERP.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;


namespace CollegeERP.Application.Services
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
                throw new KeyNotFoundException("User not found.");
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
            var user = new User
            {
                Email = userInput.Email,
                RoleId = userInput.RoleId
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, userInput.Password);
             await _repository.AddAsync(user);
            return new UserResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                RoleId = user.RoleId
            };

        }
        public async Task<UserResponse> UpdateAsync(int id, UpdateUserRequest userInput)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            user.Email = userInput.Email;
            user.RoleId = userInput.RoleId;
            await _repository.UpdateAsync(user);
            return new UserResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            user.Status = 0; 
            await _repository.UpdateAsync(user);
        }
        public async Task ChangePasswordAsync(int id , ChangePasswordRequest passwards)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, passwards.CurrentPassword);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedAccessException("Current password is incorrect.");
            }
            user.PasswordHash = _passwordHasher.HashPassword(user, passwards.NewPassword);
            await _repository.UpdateAsync(user);
        }

    }
}
