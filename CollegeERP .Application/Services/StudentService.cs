using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }
    }
}
