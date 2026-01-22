using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.DTOs.Student
{
    public class GetStudentResponse
    {
        public int StudentId { get; set; }

        public string EnrollmentNo { get; set; } = null!;

        public int CourseId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

    }
}
