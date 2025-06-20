using Domain.Entities;
using Application.IRepositories;
using Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PatientRepository : IPatientRepository
{
    private readonly ProfilesApiDbContext _context;
    public PatientRepository(ProfilesApiDbContext context)
    {
        _context = context;
    }
    public async Task<Patient> CreatePatient(Patient patient)
    {
        await _context.Patients
            .AddAsync(patient);
        return patient;
    }

    public async Task<Patient?> GetPatient(Guid id)
    {
        return await _context.Patients
            .FirstOrDefaultAsync(m => m.Patient_ID == id);
    }

    public async Task<List<Patient>> GetPatients()
    {
        return await _context.Patients
            .ToListAsync();
    }

    public async Task RemovePatient(Guid id)
    {
        _context.Patients
            .Remove
            (
                await GetPatient(id)
            );
    }

    public async Task<Patient> UpdatePatient(Guid id, Patient patient)
    {
        var tempEntry = await GetPatient(id);
        _context.Patients
            .Entry(tempEntry)
            .CurrentValues
            .SetValues(patient);
        return patient;
    }
}

