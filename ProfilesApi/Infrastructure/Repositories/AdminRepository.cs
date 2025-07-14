using Domain.Entities;
using Domain.Entities.Extensions;
using Domain.Interfaces.IRepositories;
using Domain.RequestFeatures;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.Extensions;
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

    public async Task<PagedList<Admin>> GetDoctorsAsync(AdminParameters adminParameters, CancellationToken token)
    {
        var admins = await _context.Admins.FilterByParameters(adminParameters).ToListAsync();
        
        return PagedList<Admin>.Create(admins, adminParameters.PageNumber, adminParameters.PageSize);
    }
}
