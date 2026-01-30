using CollegeERP.Domain.Data.Entities;
namespace CollegeERP_.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task<Department?> GetDepartmentByIdAsync(int departmentId);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
    }
}
