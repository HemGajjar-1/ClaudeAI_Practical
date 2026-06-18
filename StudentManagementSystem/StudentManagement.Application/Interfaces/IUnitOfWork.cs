namespace StudentManagement.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IStudentRepository Students { get; }
    Task<int> SaveChangesAsync();
}
