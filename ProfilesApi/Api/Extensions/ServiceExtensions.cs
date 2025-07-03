using Application.Doctors.UseCases.GetDoctorById;
using Application.Patients.UseCases.GetPatientById;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
    }

    public static void ConfigureMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            var applicationAssembly = typeof(GetDoctorByIdQuery).Assembly;
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });
        services.AddMediatR(cfg =>
        {
            var applicationAssembly = typeof(GetPatientByIdQuery).Assembly;
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });
    }

    public static void ConfigureDataBaseContext(this IServiceCollection services, IConfiguration connection)
    {
        services.AddDbContext<ProfilesApiDbContext>(options => options.UseSqlServer(connection.GetConnectionString("sqlConnection")));
    }

    public static void ConfigureValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(GetDoctorByIdQueryValidator).Assembly); 
        services.AddValidatorsFromAssembly(typeof(GetPatientByIdQueryValidator).Assembly);   
    }
}