using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    private readonly ProfilesApiDbContext _context;

    public PatientRepository(ProfilesApiDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Patient> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.Patients.FirstOrDefaultAsync(m => m.Id == id, token);
    }
}

