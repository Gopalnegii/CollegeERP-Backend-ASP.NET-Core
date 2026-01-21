using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Application.Interfaces.Services;
using CollegeERP.Domain.Data.Entities;
using System;

using System.Collections.Generic;
using System.Text;
using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.DTOs.Department;

namespace CollegeERP_.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
       private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository) 
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments =   await _departmentRepository.GetAllDepartmentsAsync();
            
            return departments.Select(d=> new DepartmentDTO { DepartmentId =d.DepartmentId , DepartmentCode=d.DepartmentCode,DepartmentName=d.DepartmentName});
        }
        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int departmentId)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(departmentId);
            var dto = new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                DepartmentCode = department.DepartmentCode,
                DepartmentName = department.DepartmentName
            };
            return dto;

        }
        public async Task<CreateDepartmentResponseDTO> CreateDepartmentAsync(CreateDepartmentDTO dto)
        {
            Department department = new Department
            {
                DepartmentCode = dto.Code,
                DepartmentName = dto.Name,
            };
            var repositoryResponse = await _departmentRepository.CreateDepartmentAsync(department);
            var departmentResponse = new CreateDepartmentResponseDTO
            {
                DepartmentId = repositoryResponse.DepartmentId,
                Code = repositoryResponse.DepartmentCode,
                Name = repositoryResponse.DepartmentName
            };
            return departmentResponse;
        }
        public async Task DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartment(id);
        }
        public async Task<CreateDepartmentResponseDTO> UpdateDepartmentAsync(UpdateDepartmentRequest departmentRequest)
        {

           var RepositoryResponse=  await _departmentRepository.UpdateDepartmentAsync(departmentRequest.DepartmentId, departmentRequest.DepartmentCode, departmentRequest.DepartmentName);
            
            var departmentResponse = new CreateDepartmentResponseDTO
            {
                DepartmentId = RepositoryResponse.DepartmentId,
                Code = RepositoryResponse.DepartmentCode,
                Name = RepositoryResponse.DepartmentName
            };
            return departmentResponse;

        }
    }
}
