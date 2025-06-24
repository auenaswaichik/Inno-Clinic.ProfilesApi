using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbContexts;

public class ProfilesApiDbContext : DbContext
{

    public ProfilesApiDbContext(DbContextOptions<ProfilesApiDbContext> options) : base(options) { Database.EnsureDeleted(); Database.EnsureCreated(); }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Admin>().HasData();
        modelBuilder.Entity<Patient>().HasData();
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), DoctorFirstName = "Pasha", DoctorMiddleName = "Andreevich", DoctorLastName = "Swagovich", DoctorDateBirth = new DateTime(2001, 11, 12), DoctorCareerStartYear = new DateTime(2001, 11, 12)},
            new Doctor {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), DoctorFirstName = "Pasha", DoctorMiddleName = "Andreevich", DoctorLastName = "Swagovich", DoctorDateBirth = new DateTime(2001, 11, 12), DoctorCareerStartYear = new DateTime(2001, 11, 12)},
            new Doctor {Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"), DoctorFirstName = "Pasha", DoctorMiddleName = "Andreevich", DoctorLastName = "Swagovich", DoctorDateBirth = new DateTime(2001, 11, 12), DoctorCareerStartYear = new DateTime(2001, 11, 12)}
        );
    }

    public void BeginTransaction()
    {
        Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        Database.CommitTransaction();
    }

    public void RollbackTransaction()
    {
        Database.RollbackTransaction();
    }

}