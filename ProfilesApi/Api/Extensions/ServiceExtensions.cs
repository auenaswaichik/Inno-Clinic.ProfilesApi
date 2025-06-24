using Application.Doctors.Queries.GetAllDoctors;
using Application.Doctors.Queries.GetDoctorById;
using Domain.Interfaces.IManagers;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using Infrastructure.Data.DbContexts;
using Infrastructure.Mangers;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ServiceExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
    }

    public static void AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            var applicationAssembly = typeof(GetAllDoctorsQuery).Assembly;
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

    }

    public static void AddDataBaseContext(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ProfilesApiDbContext>(options => options.UseSqlServer(connection));
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(GetDoctorByIdQueryValidator).Assembly);   
    }

}