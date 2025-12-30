using CollegeERP_.Application.DTOs;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Application.Interfaces.Services;
using CollegeERP.Domain.Data.Entities;
using System;


using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
       private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository) {
            _departmentRepository = departmentRepository;
        }
        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
             var departments =   await _departmentRepository.GetAllDepartmentsAsync();
            return departments.Where(d => d.Status!=0).Select(d=> new DepartmentDTO { DepartmentId =d.DepartmentId , DepartmentCode=d.DepartmentCode,DepartmentName=d.DepartmentName});
        }
        public async Task<DepartmentDTO?> GetDepartmentByIdAsync(int departmentId)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(departmentId);
            if (department == null || department.DepartmentId==0)
            {
                return null;
            }
            var dto = new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                DepartmentCode = department.DepartmentCode,
                DepartmentName = department.DepartmentName
            };
            return dto;

        }
    }
}
