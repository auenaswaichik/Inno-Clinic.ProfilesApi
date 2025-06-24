using Domain.Interfaces.IManagers;
using Infrastructure.Data.DbContexts;

namespace Infrastructure.Mangers;

public class UnitOfWork : IUnitOfWork
{

    private readonly ProfilesApiDbContext _context;

    public UnitOfWork(ProfilesApiDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        //_context.BeginTransaction();
    }

    public void Save()
    {
        //_context.CommitTransaction();
        _context.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
        //_context.CommitTransaction();
    }

    public void Rollback()
    {
        _context.RollbackTransaction();
    }

}
