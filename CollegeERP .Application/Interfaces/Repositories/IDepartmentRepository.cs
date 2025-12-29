using CollegeERP_.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();
    }
}
