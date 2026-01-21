using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP_.Application.DTOs.Courses
{
    public class UpdateCourseRequest
    {
        [Range(1, int.MaxValue)]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; } = null!;
        [Range(1, int.MaxValue)]
        public int DepartmentId { get; set; }
        [Range(1, int.MaxValue)]
        public int TotalSemesters { get; set; }
    }
}
