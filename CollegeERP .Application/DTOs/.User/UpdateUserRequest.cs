using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP_.Application.DTOs.User
{
    public class UpdateUserRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Role Id")]
        public int RoleId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

    }
}
