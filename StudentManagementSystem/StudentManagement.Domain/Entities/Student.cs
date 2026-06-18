using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Domain.Entities;

public class Student : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public DateTime EnrollmentDate { get; set; }

    [Range(0, 100)]
    public double Grade { get; set; }
}
