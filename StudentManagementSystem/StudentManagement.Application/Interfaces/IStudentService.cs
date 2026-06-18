using StudentManagement.Application.DTOs;

namespace StudentManagement.Application.Interfaces;

public interface IStudentService
{
    Task AddAsync(CreateStudentDTO dto);
    Task<IEnumerable<StudentDTO>> GetAllAsync();
    Task<StudentDTO?> GetByIdAsync(int id);
    Task UpdateGradeAsync(int id, double grade);
    Task DeleteAsync(int id);
}
