using Domain.Entities;
using Domain.RequestFeatures;

namespace Infrastructure.Repositories.Extensions;

public static class PatientRepositoryExtensions
{   
    public static IQueryable<Patient> FilterByParameters(this IQueryable<Patient>patients, PatientParameters parameters)
    {
        return patients
            .Search(parameters.SearchTerm);
    }
    private static IQueryable<Patient> Search(this IQueryable<Patient> patients, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return patients;
        }

        return patients.Where(m => m.FirstName.Contains(searchTerm) || m.LastName.Contains(searchTerm));
    }
}