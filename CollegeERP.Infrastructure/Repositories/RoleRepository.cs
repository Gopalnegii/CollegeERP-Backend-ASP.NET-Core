using CollegeERP.Domain.Data.Entities;
using CollegeERP.Domain.Exceptions;
using CollegeERP.Application.DTOs.Role;
using CollegeERP.Application.Interfaces.Repositories;
using CollegeERP.Infrastructure.Data.Context;
using CollegeERP.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CollegeERPDbContext _context;
        public RoleRepository(CollegeERPDbContext collegeERPDbContext)
        {
            _context = collegeERPDbContext;
        }
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            
            return await _context.Roles.Where(r => r.Status != 0).ToListAsync();
        }
        public async Task<Role?> GetByIdAsync(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id && r.Status != 0);
            return role;
        }
        public async Task<Role> CreateAsync(Role roledata)
        {
            _context.Roles.Add(roledata);
            try
            {
                await _context.SaveChangesAsync();
                return roledata;
            }
            catch (DbUpdateException ex) when (DbExceptionHelper.IsUniqueConstraintViolation(ex))
            {
                throw new AlreadyExistsException($"A role with the name '{roledata.RoleName}' already exists.");
            }
        }
        public async Task UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (DbExceptionHelper.IsUniqueConstraintViolation(ex))
            {
                throw new AlreadyExistsException("A role with the same name already exists.");
            }
        }
    }
}
