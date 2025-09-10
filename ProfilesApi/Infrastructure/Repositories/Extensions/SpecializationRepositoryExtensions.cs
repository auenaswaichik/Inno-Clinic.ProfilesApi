using Domain.Entities;
using Domain.Entities.Parameters;
using Domain.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Extensions;

public static class SpecializationRepositoryExtensions
{   
    public static IQueryable<Specialization> FilterByParameters(this IQueryable<Specialization> specializations, SpecializationParameters parameters)
    {
        return specializations
            .AsNoTracking()
            .Include(s => s.Doctors)
            .Search(parameters.SearchTerm);
    }
    private static IQueryable<Specialization> Search(this IQueryable<Specialization> specializations, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return specializations;
        }

        return specializations.Where(m => m.Name.Contains(searchTerm) || m.Description.Contains(searchTerm));
    }
}