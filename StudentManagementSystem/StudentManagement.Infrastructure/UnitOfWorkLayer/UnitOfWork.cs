using StudentManagement.Application.Interfaces;
using StudentManagement.Infrastructure.Persistence;
using StudentManagement.Infrastructure.Repositories;

namespace StudentManagement.Infrastructure.UnitOfWorkLayer;

public class UnitOfWork : IUnitOfWork
{
    private readonly InMemoryDatabase _database;
    private IStudentRepository? _students;
    private bool _disposed;

    public UnitOfWork(InMemoryDatabase database)
    {
        _database = database;
    }

    public IStudentRepository Students =>
        _students ??= new StudentRepository(_database);

    public Task<int> SaveChangesAsync()
    {
        return Task.FromResult(0);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
