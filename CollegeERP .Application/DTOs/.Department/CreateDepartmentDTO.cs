using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP_.Application.DTOs.Department
{
    public class CreateDepartmentDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Code { get; set; } = null!;
    }
}
