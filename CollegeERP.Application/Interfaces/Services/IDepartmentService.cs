using CollegeERP.Domain.Data.Entities;
using CollegeERP.Application.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentResponse>CreateDepartmentAsync(CreateDepartmentDTO departmentdto);
        Task<DepartmentResponse>UpdateDepartmentAsync(int id ,UpdateDepartmentRequest departmentRequest);
        Task DeleteDepartment(int id);
        Task<DepartmentResponse> GetDepartmentByIdAsync(int departmentId);
        Task<IEnumerable<DepartmentResponse>> GetAllDepartmentsAsync();

    }
}
