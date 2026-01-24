
using CollegeERP_.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllAsync();
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> CreateAsync(CreateUserRequest userInput);
    }
}
