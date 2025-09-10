using Domain.Entities;
using Domain.Entities.Extensions;
using Domain.Interfaces.IRepositories;
using Domain.RequestFeatures;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.Extensions;
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
        return await _context.Doctors
            .Include(m => m.Specialization)
            .FirstOrDefaultAsync(m => m.Id == id, token);
    }

    public async Task<PagedList<Doctor>> GetDoctorsAsync(DoctorParameters doctorParameters, CancellationToken token)
    {
        var doctors = await _context.Doctors.FilterByParameters(doctorParameters).ToListAsync(token); 
        return PagedList<Doctor>.Create(doctors, doctorParameters.PageNumber, doctorParameters.PageSize);
    }
}
