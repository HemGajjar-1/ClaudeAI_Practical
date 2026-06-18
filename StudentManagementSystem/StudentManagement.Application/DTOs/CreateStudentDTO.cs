namespace StudentManagement.Application.DTOs;

public class CreateStudentDTO
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public double Grade { get; set; }
}
