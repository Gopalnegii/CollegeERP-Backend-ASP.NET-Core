using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP.Application.DTOs.Role
{
    public class RoleCreateRequest
    {
        [Required]
        [MaxLength(30)]
        public string RoleName { get; set; } = null!;

    }
}
