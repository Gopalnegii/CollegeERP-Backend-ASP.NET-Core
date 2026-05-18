using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeERP.Application.DTOs.User
{
    public class ChangePasswordRequest
    {
        [Required]
        [MinLength(8, ErrorMessage = "Minimum 8 Characters required")]

        public string CurrentPassword { get; set; } = null!;
        [Required]
        [MinLength(8, ErrorMessage = "Minimum 8 Characters required")]
        public string NewPassword { get; set; } = null!;
    }
}
