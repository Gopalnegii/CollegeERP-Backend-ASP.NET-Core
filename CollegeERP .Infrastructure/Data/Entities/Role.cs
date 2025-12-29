using System;
using System.Collections.Generic;

namespace CollegeERP_.Infrastructure.Data.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public byte Status { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
