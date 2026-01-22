using System;
using System.Collections.Generic;

namespace CollegeERP.Domain.Data.Entities;

public partial class StudentProfile
{
    public int StudentId { get; set; }

    public string FatherName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    public string? LastQualification { get; set; }

    public byte Status { get; set; }

    public virtual Student Student { get; set; } = null!;
}
