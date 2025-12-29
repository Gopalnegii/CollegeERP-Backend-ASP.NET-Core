using System;
using System.Collections.Generic;

namespace CollegeERP_.Infrastructure.Data.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }

    public byte Status { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Student? Student { get; set; }
}
