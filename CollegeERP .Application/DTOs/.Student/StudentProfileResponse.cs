using System;

public class StudentProfileResponse
{
    public string FatherName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string? Address { get; set; }
    public string? LastQualification { get; set; }
}
