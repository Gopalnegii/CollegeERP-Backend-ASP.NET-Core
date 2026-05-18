using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP.Application.DTOs.Department
{
    public class DepartmentResponse
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; } = null!;
        
        public string DepartmentName { get; set; } = null!;

    }
}
