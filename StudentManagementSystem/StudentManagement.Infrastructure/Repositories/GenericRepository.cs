using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
{
    private readonly List<TEntity> _store;
    private readonly Func<int> _nextId;

    protected GenericRepository(List<TEntity> store, Func<int> nextId)
    {
        _store = store;
        _nextId = nextId;
    }

    public Task AddAsync(TEntity entity)
    {
        entity.Id = _nextId();
        _store.Add(entity);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<TEntity>>(_store.ToList());
    }

    public Task<TEntity?> GetByIdAsync(int id)
    {
        return Task.FromResult(_store.FirstOrDefault(e => e.Id == id));
    }

    public Task UpdateAsync(TEntity entity)
    {
        var index = _store.FindIndex(e => e.Id == entity.Id);
        if (index >= 0)
            _store[index] = entity;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var entity = _store.FirstOrDefault(e => e.Id == id);
        if (entity is not null)
            _store.Remove(entity);
        return Task.CompletedTask;
    }
}
