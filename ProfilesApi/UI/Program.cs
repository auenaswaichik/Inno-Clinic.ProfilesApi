using Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Application.IManagers;
using Infrastructure.Mangers;
using Application.IRepositories;
using Infrastructure.Repositories;
using Application.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Env.Load();

var connection = Environment.GetEnvironmentVariable("DATABASE_URL");

builder.Services.AddDbContext<ProfilesApiDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddAutoMapper
(
    typeof(PatientProfile),
    typeof(DoctorProfile),
    typeof(AdminProfile)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
