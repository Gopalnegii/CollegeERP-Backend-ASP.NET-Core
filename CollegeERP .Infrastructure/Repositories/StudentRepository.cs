using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Infrastructure.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly CollegeERPDbContext _context;
        public StudentRepository(CollegeERPDbContext collegeERPDbContext) 
        {
            _context = collegeERPDbContext;
        }

    }
}
