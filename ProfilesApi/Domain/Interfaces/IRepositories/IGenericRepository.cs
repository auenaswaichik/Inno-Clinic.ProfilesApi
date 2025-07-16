using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces.IRepositories;

public interface IGenericRepository<T> where T : BaseUserModel
{
    public Task<List<T>> GetAllAsync(CancellationToken token);
    public T Insert(T entity);
    public T Update(T entity);
    public void Delete(T entity);
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking);
}