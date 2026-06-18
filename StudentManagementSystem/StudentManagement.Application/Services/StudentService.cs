using StudentManagement.Application.DTOs;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Application.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(CreateStudentDTO dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            EnrollmentDate = dto.EnrollmentDate,
            Grade = dto.Grade
        };

        await _unitOfWork.Students.AddAsync(student);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<StudentDTO>> GetAllAsync()
    {
        var students = await _unitOfWork.Students.GetAllAsync();
        return students.Select(MapToDTO);
    }

    public async Task<StudentDTO?> GetByIdAsync(int id)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(id);
        return student is null ? null : MapToDTO(student);
    }

    public async Task UpdateGradeAsync(int id, double grade)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Student with id {id} was not found.");

        student.Grade = grade;

        await _unitOfWork.Students.UpdateAsync(student);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Students.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    private static StudentDTO MapToDTO(Student student) => new()
    {
        Id = student.Id,
        Name = student.Name,
        Email = student.Email,
        EnrollmentDate = student.EnrollmentDate,
        Grade = student.Grade
    };
}
