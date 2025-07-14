using Domain.Entities;
using Domain.Entities.Extensions;
using Domain.Interfaces.IRepositories;
using Domain.RequestFeatures;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.Extensions;
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

    public async Task<PagedList<Patient>> GetDoctorsAsync(PatientParameters patientParameters, CancellationToken token)
    {
        var patinets = await _context.Patients.FilterByParameters(patientParameters).ToListAsync();

        return PagedList<Patient>.Create(patinets, patientParameters.PageNumber, patientParameters.PageSize);
    }
}

