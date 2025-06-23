using Domain.Entities;

namespace Domain.Interfaces.IRepositories;

public interface IGenericRepository<T> where T : User
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetById(object id);
    public Task<T> Insert(T obj);
    public T Update(T obj);
    public Task Delete(object id);
}