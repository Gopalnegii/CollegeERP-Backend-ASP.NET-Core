using System;
using System.Collections.Generic;

namespace CollegeERP_.Infrastructure.Data.Entities;

public partial class Student
{
    public int StudentId { get; set; }

    public string EnrollmentNo { get; set; } = null!;

    public int CourseId { get; set; }

    public int UserId { get; set; }

    public byte Status { get; set; }

    public string Name { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
