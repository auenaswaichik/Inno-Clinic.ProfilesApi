using Domain.Entities;
using Domain.Entities.Parameters;
using Domain.Interfaces.IRepositories;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SpecializationRepository : ISpecializationRepository
{
    private readonly ProfilesApiDbContext _context;
    public SpecializationRepository(ProfilesApiDbContext context)
    {
        _context = context;
    }

    public Specialization Insert(Specialization specialization)
    {
        _context.Specializations.Add(specialization);
        return specialization;
    }

    public void Delete(Specialization specialization)
    {
        _context.Specializations.Remove(specialization);
    }

    public async Task<List<Specialization>> GetSpecializationsAsync(SpecializationParameters parameters, CancellationToken token)
    {
        var specializations = await _context.Specializations.FilterByParameters(parameters).ToListAsync(token);
        return specializations;       
    }

    public async Task<Specialization> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.Specializations
            .AsNoTracking()
            .Include(s => s.Doctors)
            .FirstOrDefaultAsync(m => m.Id == id, token);
    }

    public Specialization Update(Specialization specialization)
    {
        _context.Specializations.Update(specialization);
        return specialization;
    }
}