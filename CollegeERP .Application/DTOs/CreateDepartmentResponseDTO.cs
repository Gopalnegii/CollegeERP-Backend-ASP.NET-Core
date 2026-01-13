using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.DTOs
{
    public class CreateDepartmentResponseDTO
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;
    }
}
