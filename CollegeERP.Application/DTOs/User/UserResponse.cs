using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Application.DTOs.User
{
    public class UserResponse
    {
        public int UserId { get; set; }

        public string Email { get; set; } = null!;

        public int RoleId { get; set; }
    }
}
