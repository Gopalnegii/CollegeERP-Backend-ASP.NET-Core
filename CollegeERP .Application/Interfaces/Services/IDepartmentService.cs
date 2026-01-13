using CollegeERP.Domain.Data.Entities;
using CollegeERP_.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<CreateDepartmentResponseDTO>CreateDepartmentAsync(CreateDepartmentDTO departmentdto);
        Task<CreateDepartmentResponseDTO>UpdateDepartmentAsync(UpdateDepartmentRequest departmentRequest);
        Task DeleteDepartment(int id);
        Task<DepartmentDTO?> GetDepartmentByIdAsync(int departmentId);
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();

    }
}
