using StudentManagement.Domain.Entities;

namespace StudentManagement.Infrastructure.Persistence;

public sealed class InMemoryDatabase
{
    private readonly List<Student> _students = new();
    private int _nextId = 1;

    internal List<Student> Students => _students;

    internal int NextId() => _nextId++;
}
