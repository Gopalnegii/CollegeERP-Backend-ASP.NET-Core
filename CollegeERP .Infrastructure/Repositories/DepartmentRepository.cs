using System;
using System.Collections.Generic;
using System.Text;
using CollegeERP_.Application.DTOs;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CollegeERP_.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CollegeERPDbContext _context;
        public DepartmentRepository(CollegeERPDbContext context ) { 
            _context = context;
        }
        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.AsNoTracking()
                .Where(d => d.Status == 1)
                .Select(d => new DepartmentDTO
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentCode = d.DepartmentCode,
                    DepartmentName = d.DepartmentName
                })
                .ToListAsync();
        }
    }
}
