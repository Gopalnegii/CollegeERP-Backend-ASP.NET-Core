using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Application.DTOs.Courses
{
    public class GetCourseResponse
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; } = null!;

        public int DepartmentId { get; set; }

        public int TotalSemesters { get; set; }
    }
}
