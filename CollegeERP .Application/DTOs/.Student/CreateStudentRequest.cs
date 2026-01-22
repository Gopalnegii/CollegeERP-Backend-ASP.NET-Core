using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP_.Application.DTOs.Student
{
    public class CreateStudentRequest
    {
        // Student fields
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string EnrollmentNo { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CourseId must be greater than 0")]
        public int CourseId { get; set; }

        // User fields
        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;
    }

}
