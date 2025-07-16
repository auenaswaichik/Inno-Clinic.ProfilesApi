using Domain.Entities;
using Domain.RequestFeatures;

namespace Infrastructure.Repositories.Extensions;

public static class DoctorRepositoryExtension
{
    public static Guid DefaultGuid = new Guid();
   
    public static IQueryable<Doctor> FilterByParameters(this IQueryable<Doctor> doctors, DoctorParameters parameters)
    {
        return doctors
            .FilterBySpecialization(parameters.SpecializationId)
            .FilterByOffice(parameters.OfficeId)
            .Search(parameters.SearchTerm);
    }

    private static IQueryable<Doctor> FilterBySpecialization(this IQueryable<Doctor> doctors, Guid specializationId)
    {
        if (specializationId == DefaultGuid)
        {
            return doctors;
        }

        return doctors.Where(m => m.SpecializationId == specializationId);
    }

    private static IQueryable<Doctor> FilterByOffice(this IQueryable<Doctor> doctors, Guid officeId)
    {
        if (officeId == DefaultGuid)
        {
            return doctors;
        }

        return doctors.Where(m => m.OfficeId == officeId);
    }

    private static IQueryable<Doctor> Search(this IQueryable<Doctor> doctors, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return doctors;
        }

        return doctors.Where(m => m.FirstName.Contains(searchTerm) || m.LastName.Contains(searchTerm));
    }
}