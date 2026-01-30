using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP_.Application.DTOs.Department
{
    public class UpdateDepartmentRequest
    {
        [Required]
        public string DepartmentCode { get; set; } = null!;
        [Required]
        public string DepartmentName { get; set; } = null!;
    }
}
