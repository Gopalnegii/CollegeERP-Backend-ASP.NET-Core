using System;
using System.Collections.Generic;

namespace CollegeERP.Domain.Data.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentCode { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public byte Status { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
