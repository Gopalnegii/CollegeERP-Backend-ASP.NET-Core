using CollegeERP.Domain.Data.Entities;
using CollegeERP_.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> GetDepartmentByIdAsync(int departmentId);
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();

    }
}
