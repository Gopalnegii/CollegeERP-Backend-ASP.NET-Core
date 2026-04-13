using CollegeERP.Domain.Data.Entities;
using CollegeERP_.Application.DTOs.Role;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<IEnumerable<RoleResponse>> GetAllAsync()
        {
               var repositoryResponse =  await _roleRepository.GetAllAsync();
            var roles = repositoryResponse.Select(role => new RoleResponse
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
            });
            return roles;
        }
        public async Task<RoleResponse> GetByIdAsync(int id)
        {

               var repositoryResponse = await _roleRepository.GetByIdAsync(id);
            if(repositoryResponse == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }
            var role = new RoleResponse
            {
                RoleId = repositoryResponse.RoleId,
                RoleName = repositoryResponse.RoleName,
            };
            return role;
        }
        public async Task<RoleResponse> CreateAsync(RoleCreateRequest requestData)
        {
            var roleEntity = new Role
            {
                RoleName = requestData.RoleName,
            };
            var createdRole = await _roleRepository.CreateAsync(roleEntity);
            var role = new RoleResponse
            {
                RoleId = createdRole.RoleId,
                RoleName = createdRole.RoleName,
            };
            return role;
        }
        public async Task<RoleResponse> UpdateAsync(int id , RoleUpdateRequest roleUpdateRequest)
        {
            var existingRole = await _roleRepository.GetByIdAsync(id);
            if(existingRole == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }
            existingRole.RoleName = roleUpdateRequest.RoleName;
             await _roleRepository.UpdateAsync(existingRole);
            var role = new RoleResponse { RoleId = existingRole.RoleId, RoleName = existingRole.RoleName };
            return role;
        }
        public async Task DeleteAsync(int id)
        {
            var existingRole = await _roleRepository.GetByIdAsync(id);
            if (existingRole == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }
            existingRole.Status = 0; // Soft delete by setting status to 0
            await _roleRepository.UpdateAsync(existingRole);
        }
    }
}
