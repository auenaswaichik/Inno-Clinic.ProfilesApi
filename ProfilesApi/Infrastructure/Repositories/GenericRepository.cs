using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : User
{

    private readonly ProfilesApiDbContext _context;

    private readonly DbSet<T> _table;

    public GenericRepository(ProfilesApiDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task Delete(object id, CancellationToken token)
    {
        _table.Remove
        (
            await GetById(id, token)
        );
    }

    public async Task<List<T>> GetAll(CancellationToken token)
    {
        return await _table.ToListAsync();
    }

    public async Task<T> GetById(object id, CancellationToken token)
    {
        return await _table.FindAsync(id);
    }

    public T Insert(T obj, CancellationToken token)
    {
        _table.Add(obj);
        return obj;
    }

    public T Update(T obj, CancellationToken token)
    {
        _table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
        return obj;
    }

}