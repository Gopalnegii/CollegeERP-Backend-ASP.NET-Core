using CollegeERP.Domain.Data.Entities;
namespace CollegeERP.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task<Department?> GetDepartmentByIdAsync(int departmentId);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
    }
}
