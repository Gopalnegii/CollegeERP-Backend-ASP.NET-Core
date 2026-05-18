using System;
using System.ComponentModel.DataAnnotations;

public class StudentProfileRequest
{
    [Required]
    [StringLength(100)]
    public string FatherName { get; set; } = null!;

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(200)]
    public string? Address { get; set; }

    [StringLength(100)]
    public string? LastQualification { get; set; }
}
