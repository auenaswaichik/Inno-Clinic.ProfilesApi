using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseUserModel
{
    private readonly ProfilesApiDbContext _context;

    public GenericRepository(ProfilesApiDbContext context)
    {
        _context = context;
    }

    public void Delete(T entity)
    {
        _context.Set<T>()
            .Remove(entity);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken token)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync(token);
    }
    public T Insert(T entity)
    {
        _context.Set<T>().Add(entity);
        return entity;
    }

    public T Update(T entity)
    {
        _context.Set<T>()
            .Update(entity);
        return entity;
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        return isTracking ? _context.Set<T>().Where(expression)
            : _context.Set<T>().Where(expression).AsNoTracking();
    }
}