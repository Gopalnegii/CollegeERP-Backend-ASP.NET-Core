using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP.Application.DTOs.User
{
    public class CreateUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(8,ErrorMessage = "Minimum 8 Characters required")]
        public string Password { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="Invalid Role Id")]
        public int RoleId { get; set; }

    }
}
