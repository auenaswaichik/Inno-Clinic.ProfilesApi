using Application.Admins.UseCases.GetAdminById;
using Application.Doctors.UseCases.GetDoctorById;
using Application.Patients.UseCases.GetPatientById;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using Infrastructure.DbContexts;
using Infrastructure.Messages.PatientRegisteredMessages;
using Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
        services.AddMediatR(cfg =>
        {
            var applicationAssembly = typeof(GetAdminByIdQuery).Assembly;
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });
    }

    public static void ConfigureAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            options.AddPolicy("DoctorOnly", policy => policy.RequireRole("Doctor"));
            options.AddPolicy("AdminOrDoctorAccess", policy =>
                policy.RequireRole("Admin", "Doctor"));
            options.AddPolicy("PatientOnly", policy => policy.RequireRole("Patient"));
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
        services.AddValidatorsFromAssembly(typeof(GetAdminByIdQueryValidator).Assembly);
    }

    public static void ConfigureSerilog(this IHostBuilder host)
    {
        host.UseSerilog((ctx, config) => config.ReadFrom.Configuration(ctx.Configuration));
    }

    public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<PatientRegisteredConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMQ:Host"], "/", h =>
                {
                    h.Username(configuration["RabbitMQ:Username"]);
                    h.Password(configuration["RabbitMQ:Password"]);
                });

                cfg.ReceiveEndpoint("patient-registered", e =>
                {
                    e.PrefetchCount = 32;
                    e.Durable = true;
                    e.AutoDelete = false;

                    e.UseInMemoryOutbox();
                    e.UseMessageRetry(r => r.Interval(5, TimeSpan.FromSeconds(10)));

                    e.ConfigureConsumer<PatientRegisteredConsumer>(context);
                });

            });
            
            
        });
    }
}