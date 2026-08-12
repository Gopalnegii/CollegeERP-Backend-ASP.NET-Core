using CollegeERP.Domain.Data.Entities;
using CollegeERP.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Infrastructure.Repositories
{
    public class StudentRepository
    {
        private readonly CollegeERPDbContext _context;
        public StudentRepository(CollegeERPDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
