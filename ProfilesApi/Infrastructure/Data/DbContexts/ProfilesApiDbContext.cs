using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbContexts;

public class ProfilesApiDbContext : DbContext
{
    public ProfilesApiDbContext(DbContextOptions<ProfilesApiDbContext> options) : base(options) { Database.EnsureCreated(); }
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>()
            .HasKey(m => m.Admin_ID);
        modelBuilder.Entity<Patient>()
            .HasKey(m => m.Patient_ID);
        modelBuilder.Entity<Doctor>()
            .HasKey(m => m.Doctor_ID);
    }
}