using Domain.Interfaces.IRepositories;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProfilesApiDbContext _context;

    public UnitOfWork(ProfilesApiDbContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync(CancellationToken token)
    {
        await _context.SaveChangesAsync(token);
    }

    public void Rollback()
    {
        _context.ChangeTracker.Clear();
    }
}
