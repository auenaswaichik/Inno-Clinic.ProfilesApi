using Domain.Entities;
using Domain.RequestFeatures;

namespace Infrastructure.Repositories.Extensions;

public static class AdminRepositoryExtensions
{
    public static Guid DefaultGuid = new Guid();
   
    public static IQueryable<Admin> FilterByParameters(this IQueryable<Admin> admins, AdminParameters parameters)
    {
        return admins
            .FilterByOffice(parameters.OfficeId)
            .Search(parameters.SearchTerm);
    }

    private static IQueryable<Admin> FilterByOffice(this IQueryable<Admin> admins, Guid officeId)
    {
        if (officeId == DefaultGuid)
        {
            return admins;
        }

        return admins.Where(m => m.OfficeId == officeId);
    }

    private static IQueryable<Admin> Search(this IQueryable<Admin> admins, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return admins;
        }

        return admins.Where(m => m.FirstName.Contains(searchTerm) || m.LastName.Contains(searchTerm));
    }
}