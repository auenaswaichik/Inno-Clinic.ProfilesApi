using Domain.Entities;
using Application.IRepositories;
using Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class DoctorRepository : IDoctorRepository
{

    private readonly ProfilesApiDbContext _context;
    public DoctorRepository(ProfilesApiDbContext context)
    {
        _context = context;
    }
    public async Task<Doctor> CreateDoctor(Doctor doctor)
    {
        await _context.Doctors
            .AddAsync(doctor);
        return doctor;
    }

    public async Task<Doctor?> GetDoctor(Guid id)
    {
        return await _context.Doctors
            .FirstOrDefaultAsync(m => m.Doctor_ID == id);
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        return await _context.Doctors
            .ToListAsync();
    }

    public async Task RemoveDoctor(Guid id)
    {
        _context.Doctors
            .Remove
            (
                await GetDoctor(id)
            );
    }

    public async Task<Doctor> UpdateDoctor(Guid id, Doctor doctor)
    {
        var tempEntry = await GetDoctor(id);
        _context.Doctors
            .Entry(tempEntry)
            .CurrentValues
            .SetValues(doctor);
        return doctor;
    }
}
