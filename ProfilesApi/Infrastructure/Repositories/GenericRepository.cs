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
        _context.Set<T>().Remove(entity);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken token)
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(object id, CancellationToken token)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public T Insert(T obj)
    {
        _context.Set<T>().Add(obj);
        return obj;
    }

    public T Update(T obj)
    {
        _context.Set<T>().Update(obj);
        return obj;
    }

}