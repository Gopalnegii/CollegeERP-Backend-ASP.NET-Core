using CollegeERP_.Application.DTOs;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Application.Interfaces.Services;
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
            return await _departmentRepository.GetAllDepartmentsAsync();
        }
    }
}
