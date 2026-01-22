using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP_.Application.DTOs.Student
{
    public class UpdateStudentRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CourseId must be greater than 0")]
        public int CourseId { get; set; }

    }
}
