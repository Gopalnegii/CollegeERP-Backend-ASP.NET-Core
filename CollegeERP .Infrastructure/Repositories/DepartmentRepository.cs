using System;
using System.Collections.Generic;
using System.Text;
using CollegeERP_.Application.DTOs;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Infrastructure.Data.Context;
using CollegeERP.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollegeERP_.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CollegeERPDbContext _context;
        public DepartmentRepository(CollegeERPDbContext context ) { 
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }
        public async Task<Department?> GetDepartmentByIdAsync(int departmentId)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }
    }
}
