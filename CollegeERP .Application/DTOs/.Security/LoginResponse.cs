using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.DTOs.Security
{
    public class LoginResponse
    {
        public string Token { get; set; } = null!;
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
