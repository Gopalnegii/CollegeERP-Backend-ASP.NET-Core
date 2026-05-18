using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP.Application.DTOs.Student
{
    public class CreateStudentRequest
    {
       
            [Required]
            [StringLength(20)]
            public string EnrollmentNo { get; set; } = null!;

            [Required]
            public int CourseId { get; set; }

            [Required]
            public int UserId { get; set; }
        

    }

}
