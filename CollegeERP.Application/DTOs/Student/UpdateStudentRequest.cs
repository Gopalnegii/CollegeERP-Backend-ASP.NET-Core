using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP.Application.DTOs.Student
{
    public class UpdateStudentRequest
    {
       
            [Required]
            public int CourseId { get; set; }
    }
}
