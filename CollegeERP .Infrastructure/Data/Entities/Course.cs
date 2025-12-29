using System;
using System.Collections.Generic;

namespace CollegeERP_.Infrastructure.Data.Entities;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int TotalSemesters { get; set; }

    public byte Status { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
