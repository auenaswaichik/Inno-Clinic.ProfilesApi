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
    public async Task Delete(object id)
    {
        _table.Remove
        (
            await GetById(id)
        );
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _table.ToListAsync();
    }

    public async Task<T> GetById(object id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<T> Insert(T obj)
    {
        await _table.AddAsync(obj);
        return obj;
    }

    public T Update(T obj)
    {
        _table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
        return obj;
    }
}