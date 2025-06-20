using Domain.Entities;
using Application.IRepositories;
using Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
public class AdminRepository : IAdminRepository
{
    private readonly ProfilesApiDbContext _context;
    public AdminRepository(ProfilesApiDbContext context)
    {
        _context = context;
    }
    public async Task<Admin> CreateAdmin(Admin admin)
    {
        await _context.Admins
            .AddAsync(admin);
        return admin;
    }

    public async Task<Admin?> GetAdmin(Guid id)
    {
        return await _context.Admins
            .FirstOrDefaultAsync(m => m.Admin_ID == id);
    }

    public async Task<List<Admin>> GetAdmins()
    {
        return await _context.Admins
            .ToListAsync();
    }

    public async Task RemoveAdmin(Guid id)
    {
        _context.Admins
            .Remove
            (
                await GetAdmin(id)
            );
    }

    public async Task<Admin> UpdateAdmin(Guid id, Admin admin)
    {
        var tempEntry = await GetAdmin(id);
        _context.Admins
            .Entry(tempEntry)
            .CurrentValues
            .SetValues(admin);
        return admin;
    }
}
