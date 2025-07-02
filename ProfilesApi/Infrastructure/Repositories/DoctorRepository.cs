using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    private readonly ProfilesApiDbContext _context;

    public DoctorRepository(ProfilesApiDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Doctor> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.Doctors.FirstOrDefaultAsync(m => m.Id == id);
    }
}
