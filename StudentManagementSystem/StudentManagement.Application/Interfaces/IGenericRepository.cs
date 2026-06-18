using StudentManagement.Domain.Entities;

namespace StudentManagement.Application.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class, IEntity
{
    Task AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
}
