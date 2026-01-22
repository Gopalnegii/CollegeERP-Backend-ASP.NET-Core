using CollegeERP.Domain.Data.Entities;
namespace CollegeERP_.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateDepartmentAsync(Department department);
        Task DeleteDepartment(int id);
        Task<Department> UpdateDepartmentAsync(int id, string code, string name);
        Task<Department> GetDepartmentByIdAsync(int departmentId);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
    }
}
