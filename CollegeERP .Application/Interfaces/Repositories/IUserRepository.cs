using CollegeERP.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<bool> EmailExistsAsync(string email, int? id=null);
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}
