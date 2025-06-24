using Domain.Entities;

namespace Domain.Interfaces.IRepositories;

public interface IGenericRepository<T> where T : User
{
    
    public Task<List<T>> GetAll(CancellationToken token);

    public Task<T> GetById(object id, CancellationToken token);

    public T Insert(T obj, CancellationToken token);

    public T Update(T obj, CancellationToken token);

    public Task Delete(object id, CancellationToken token);

}