
using CollegeERP.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllAsync();
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> CreateAsync(CreateUserRequest userInput);
        Task<UserResponse> UpdateAsync(int id, UpdateUserRequest userInput);
        Task DeleteAsync(int id);
        Task ChangePasswordAsync(int id, ChangePasswordRequest passwards);
    }
}
