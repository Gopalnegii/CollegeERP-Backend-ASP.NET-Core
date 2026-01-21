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
                throw new AlreadyExistsException($"Department '{department.DepartmentName}' already Exists"); 
            }
            return department;
        }
        public async Task<Department> UpdateDepartmentAsync(int id, string code, string name)
        {
            var existence = await _context.Departments.FirstOrDefaultAsync(d=>d.DepartmentId == id && d.Status==1);

            if (existence == null)
            {
                throw new KeyNotFoundException("Department not found");
            }
            existence.DepartmentName = name;
            existence.DepartmentCode = code;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (IsUniqueViolation(ex)) 
            {
                throw new AlreadyExistsException($"Department '{existence.DepartmentName}' already Exists"); 
            }
            return existence;
        }
        public async Task DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if(department == null || department.Status==0)
            {
                throw new KeyNotFoundException("Department not found");

            }

            department.Status = 0;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            var dept = await _context.Departments.Where(d => d.Status != 0).ToListAsync(); 
            return dept;
        }
        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            var dept = await _context.Departments
         .FirstOrDefaultAsync(d => d.DepartmentId == departmentId && d.Status != 0);

            if (dept == null)
                throw new KeyNotFoundException("Department not found");

            return dept;
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
