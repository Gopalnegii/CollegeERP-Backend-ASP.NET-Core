using CollegeERP.Domain.Data.Entities;
using CollegeERP_.Application.DTOs.Department;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Application.Interfaces.Services;

namespace CollegeERP_.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
       private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository) 
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IEnumerable<DepartmentResponse>> GetAllDepartmentsAsync()
        {
            var departments =   await _departmentRepository.GetAllDepartmentsAsync();
            
            return departments.Select(d=> new DepartmentResponse { 
                DepartmentId =d.DepartmentId,
                DepartmentCode=d.DepartmentCode,
                DepartmentName=d.DepartmentName});
        }
        public async Task<DepartmentResponse> GetDepartmentByIdAsync(int departmentId)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(departmentId);
            if(department == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }
            var dto = new DepartmentResponse
            {
                DepartmentId = department.DepartmentId,
                DepartmentCode = department.DepartmentCode,
                DepartmentName = department.DepartmentName
            };
            return dto;

        }
        public async Task<DepartmentResponse> CreateDepartmentAsync(CreateDepartmentDTO dto)
        {
            Department department = new Department
            {
                DepartmentCode = dto.Code,
                DepartmentName = dto.Name,
            };
            var repositoryResponse = await _departmentRepository.CreateDepartmentAsync(department);
            var departmentResponse = new DepartmentResponse
            {
                DepartmentId = repositoryResponse.DepartmentId,
                DepartmentCode = repositoryResponse.DepartmentCode,
                DepartmentName = repositoryResponse.DepartmentName
            };
            return departmentResponse;
        }
        public async Task DeleteDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if(department == null)
            {
                throw new KeyNotFoundException("Department not found");
            }
            department.Status = 0;
            await _departmentRepository.UpdateDepartmentAsync(department);
        }
        public async Task<DepartmentResponse> UpdateDepartmentAsync(int id, UpdateDepartmentRequest departmentRequest)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if(department == null)
            {
                throw new KeyNotFoundException("Department not found");
            }
            department.DepartmentName = departmentRequest.DepartmentName;
            department.DepartmentCode = departmentRequest.DepartmentCode;
            await _departmentRepository.UpdateDepartmentAsync(department);
            return new DepartmentResponse
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                DepartmentCode = department.DepartmentCode,
            };

        }
    }
}
