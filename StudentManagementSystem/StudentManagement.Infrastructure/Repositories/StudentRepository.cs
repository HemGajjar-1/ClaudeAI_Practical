using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Entities;
using StudentManagement.Infrastructure.Persistence;

namespace StudentManagement.Infrastructure.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(InMemoryDatabase database)
        : base(database.Students, database.NextId)
    {
    }
}
