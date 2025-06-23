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