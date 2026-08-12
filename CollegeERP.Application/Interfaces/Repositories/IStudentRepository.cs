using CollegeERP.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Application.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> CreateAsync(Student student);

        Task<Student?> GetByIdAsync(int studentId);

        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student> UpdateAsync(Student student);

        Task<bool> DeleteAsync(int studentId);
    }
}
