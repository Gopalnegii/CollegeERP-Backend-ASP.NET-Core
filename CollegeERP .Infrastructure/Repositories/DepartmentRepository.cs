using CollegeERP.Domain.Data.Entities;
using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.DTOs;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Infrastructure.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CollegeERPDbContext _context;
        public DepartmentRepository(CollegeERPDbContext context ) { 
            _context = context;
        }
        public async Task<Department> CreateDepartmentAsync(Department department)
        {
         _context.Departments.Add(department);
            try
            {
            await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex) when (IsUniqueViolation(ex))
            {
                throw new DepartmentAlreadyExistsException(department.DepartmentName); 
            }
            return department;
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }
        public async Task<Department?> GetDepartmentByIdAsync(int departmentId)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        //Helper methods 
        private static bool IsUniqueViolation(DbUpdateException ex)
        {
            var sqlException = ex.InnerException as SqlException;

            if (sqlException == null)
                return false;

            return sqlException.Number == 2627 || sqlException.Number == 2601;
        }
    }
}
