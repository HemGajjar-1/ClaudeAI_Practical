using StudentManagement.Application.DTOs;
using StudentManagement.Application.Interfaces;

namespace StudentManagement.Console.UI;

public class StudentMenu
{
    private readonly IStudentService _studentService;

    public StudentMenu(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            PrintMenu();
            var choice = System.Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1": await AddStudentAsync(); break;
                case "2": await ViewAllStudentsAsync(); break;
                case "3": await GetStudentByIdAsync(); break;
                case "4": await UpdateGradeAsync(); break;
                case "5": await DeleteStudentAsync(); break;
                case "0":
                    System.Console.WriteLine("Exiting...");
                    return;
                default:
                    System.Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            System.Console.WriteLine();
        }
    }

    private static void PrintMenu()
    {
        System.Console.WriteLine("=== Student Management System ===");
        System.Console.WriteLine("1. Add Student");
        System.Console.WriteLine("2. View All Students");
        System.Console.WriteLine("3. Get Student by ID");
        System.Console.WriteLine("4. Update Grade");
        System.Console.WriteLine("5. Delete Student");
        System.Console.WriteLine("0. Exit");
        System.Console.Write("Select option: ");
    }

    private async Task AddStudentAsync()
    {
        System.Console.Write("Name: ");
        var name = System.Console.ReadLine() ?? string.Empty;

        System.Console.Write("Email: ");
        var email = System.Console.ReadLine() ?? string.Empty;

        System.Console.Write("Enrollment Date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(System.Console.ReadLine(), out var enrollmentDate))
        {
            System.Console.WriteLine("Invalid date format.");
            return;
        }

        System.Console.Write("Grade (0-100): ");
        if (!double.TryParse(System.Console.ReadLine(), out var grade) || grade < 0 || grade > 100)
        {
            System.Console.WriteLine("Invalid grade. Must be between 0 and 100.");
            return;
        }

        var dto = new CreateStudentDTO
        {
            Name = name,
            Email = email,
            EnrollmentDate = enrollmentDate,
            Grade = grade
        };

        await _studentService.AddAsync(dto);
        System.Console.WriteLine("Student added successfully.");
    }

    private async Task ViewAllStudentsAsync()
    {
        var students = await _studentService.GetAllAsync();
        var list = students.ToList();

        if (list.Count == 0)
        {
            System.Console.WriteLine("No students found.");
            return;
        }

        System.Console.WriteLine($"{"ID",-5} {"Name",-25} {"Email",-30} {"Enrolled",-15} {"Grade",-6}");
        System.Console.WriteLine(new string('-', 85));

        foreach (var s in list)
        {
            System.Console.WriteLine(
                $"{s.Id,-5} {s.Name,-25} {s.Email,-30} {s.EnrollmentDate:yyyy-MM-dd} {s.Grade,-6}");
        }
    }

    private async Task GetStudentByIdAsync()
    {
        System.Console.Write("Enter Student ID: ");
        if (!int.TryParse(System.Console.ReadLine(), out var id))
        {
            System.Console.WriteLine("Invalid ID.");
            return;
        }

        var student = await _studentService.GetByIdAsync(id);

        if (student is null)
        {
            System.Console.WriteLine($"No student found with ID {id}.");
            return;
        }

        System.Console.WriteLine($"ID:             {student.Id}");
        System.Console.WriteLine($"Name:           {student.Name}");
        System.Console.WriteLine($"Email:          {student.Email}");
        System.Console.WriteLine($"Enrolled:       {student.EnrollmentDate:yyyy-MM-dd}");
        System.Console.WriteLine($"Grade:          {student.Grade}");
    }

    private async Task UpdateGradeAsync()
    {
        System.Console.Write("Enter Student ID: ");
        if (!int.TryParse(System.Console.ReadLine(), out var id))
        {
            System.Console.WriteLine("Invalid ID.");
            return;
        }

        System.Console.Write("New Grade (0-100): ");
        if (!double.TryParse(System.Console.ReadLine(), out var grade) || grade < 0 || grade > 100)
        {
            System.Console.WriteLine("Invalid grade. Must be between 0 and 100.");
            return;
        }

        try
        {
            await _studentService.UpdateGradeAsync(id, grade);
            System.Console.WriteLine("Grade updated successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    private async Task DeleteStudentAsync()
    {
        System.Console.Write("Enter Student ID: ");
        if (!int.TryParse(System.Console.ReadLine(), out var id))
        {
            System.Console.WriteLine("Invalid ID.");
            return;
        }

        await _studentService.DeleteAsync(id);
        System.Console.WriteLine("Student deleted successfully.");
    }
}
