using Domain.Interfaces.IManagers;
using Infrastructure.Data.DbContexts;

namespace Infrastructure.Mangers;
public class RepositoryManager : IRepositoryManager
{
    private readonly ProfilesApiDbContext _context;
    public RepositoryManager(ProfilesApiDbContext context)
    {
        _context = context;
    }
    public void Save()
    {
        _context.SaveChanges();
    }
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
