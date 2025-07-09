using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AdminRepository : GenericRepository<Admin>, IAdminRepository
{
    private readonly ProfilesApiDbContext _context;
    public AdminRepository(ProfilesApiDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Admin> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.Admins.FirstOrDefaultAsync(m => m.Id == id);
    }
}
