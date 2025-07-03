using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts;

public class ProfilesApiDbContext : DbContext
{
    public ProfilesApiDbContext(DbContextOptions<ProfilesApiDbContext> options) : base(options) { }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Admin>()
            .HasKey(m => m.Id);

        modelBuilder.Entity<Doctor>()
            .HasKey(m => m.Id);

        modelBuilder.Entity<Patient>()
            .HasKey(m => m.Id);

        modelBuilder.Entity<Admin>().HasData(
            new Patient {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"), FirstName = "Ilia", LastName = "Kustovich", DateBirth = new DateTime(2001, 11, 12)},
            new Patient {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"), FirstName = "Ilia", LastName = "Kustovich", DateBirth = new DateTime(2001, 11, 12)},
            new Patient {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"), FirstName = "Ilia", LastName = "Kustovich", DateBirth = new DateTime(2001, 11, 12)}
        );

        modelBuilder.Entity<Patient>().HasData();
        
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), FirstName = "Pasha", LastName = "Swagovich", DateBirth = new DateTime(2001, 11, 12), CareerStartYear = new DateTime(2001, 11, 12)},
            new Doctor {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), FirstName = "Pasha", LastName = "Swagovich", DateBirth = new DateTime(2001, 11, 12), CareerStartYear = new DateTime(2001, 11, 12)},
            new Doctor {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"), FirstName = "Pasha", LastName = "Swagovich", DateBirth = new DateTime(2001, 11, 12), CareerStartYear = new DateTime(2001, 11, 12)}
        );
    }
}