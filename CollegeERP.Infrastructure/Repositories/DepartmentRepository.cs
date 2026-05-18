using CollegeERP.Domain.Data.Entities;
using CollegeERP.Domain.Exceptions;
using CollegeERP.Application.Interfaces.Repositories;
using CollegeERP.Infrastructure.Data.Context;
using CollegeERP.Infrastructure.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CollegeERP.Infrastructure.Repositories
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
            catch (DbUpdateException ex) when (DbExceptionHelper.IsUniqueConstraintViolation(ex))
            {
                throw new AlreadyExistsException($"Department '{department.DepartmentName}' already Exists"); 
            }
            return department;
        }
        public async Task UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (DbExceptionHelper.IsUniqueConstraintViolation(ex)) 
            {
                throw new AlreadyExistsException($"Department '{department.DepartmentName}' already Exists"); 
            }
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            var dept = await _context.Departments.Where(d => d.Status != 0).ToListAsync(); 
            return dept;
        }
        public async Task<Department?> GetDepartmentByIdAsync(int departmentId)
        {
            var dept = await _context.Departments.Where(d => d.DepartmentId == departmentId && d.Status != 0).FirstOrDefaultAsync();
            return dept;
        }
    }
}
