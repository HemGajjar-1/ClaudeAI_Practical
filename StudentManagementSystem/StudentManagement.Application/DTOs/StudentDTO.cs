namespace StudentManagement.Application.DTOs;

public class StudentDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public double Grade { get; set; }
}
