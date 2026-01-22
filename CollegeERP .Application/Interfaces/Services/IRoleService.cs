using CollegeERP_.Application.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponse>> GetAllAsync();
        Task<RoleResponse> GetByIdAsync(int id);
        Task<RoleResponse> CreateAsync(RoleCreateRequest requestData);
        Task<RoleResponse> UpdateAsync(int id , RoleUpdateRequest roleUpdateRequest);
        Task DeleteAsync(int id);
    }
}
