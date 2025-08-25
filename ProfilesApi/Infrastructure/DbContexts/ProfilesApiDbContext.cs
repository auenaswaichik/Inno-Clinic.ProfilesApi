using Domain.Entities;
using Domain.Entities.Extensions;
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
            .HasQueryFilter(m => !m.IsDeleted)
            .HasKey(m => m.Id);

        modelBuilder.Entity<Admin>().HasData(
            new Admin { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"), Email = "coolguy@test.com", FirstName = "Admin", LastName = "Abaldet", DateBirth = new DateTime(1999, 11, 12) },
            new Admin { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"), Email = "coolguy@test.com", FirstName = "Admin", LastName = "Abaldet", DateBirth = new DateTime(1999, 11, 12) },
            new Admin { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"), Email = "coolguy@test.com", FirstName = "Admin", LastName = "Abaldet", DateBirth = new DateTime(1999, 11, 12) }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"), Email = "coolguy@test.com", FirstName = "Ilia", LastName = "Kustovich", DateBirth = new DateTime(2000, 11, 12) },
            new Patient { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"), Email = "coolguy@test.com", FirstName = "Ilia", LastName = "Kustovich", DateBirth = new DateTime(2000, 11, 12) },
            new Patient { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"), Email = "coolguy@test.com", FirstName = "Ilia", LastName = "Kustovich", DateBirth = new DateTime(2000, 11, 12) }
        );

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),Email = "coolguy@test.com", FirstName = "Pasha", LastName = "Swagovich", DateBirth = new DateTime(2001, 11, 12), CareerStartYear = new DateTime(2001, 11, 12) },
            new Doctor { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),Email = "coolguy@test.com", FirstName = "Pasha", LastName = "Swagovich", DateBirth = new DateTime(2001, 11, 12), CareerStartYear = new DateTime(2001, 11, 12) },
            new Doctor { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"),Email = "coolguy@test.com", FirstName = "Pasha", LastName = "Swagovich", DateBirth = new DateTime(2001, 11, 12), CareerStartYear = new DateTime(2001, 11, 12) }
        );
    }

    public override async Task<int> SaveChangesAsync(CancellationToken token)
    {
        HandleSoftDelete();
        return await base.SaveChangesAsync();
    }

    public override int SaveChanges()
    {
        HandleSoftDelete();
        return base.SaveChanges();
    }

    private void HandleSoftDelete()
    {
        var entries = ChangeTracker.Entries()
                .Where(m => m.State == EntityState.Deleted && m.Entity is SoftDelete);

        foreach (var entry in entries)
        {
            entry.State = EntityState.Modified;

            var softDelete = (SoftDelete)entry.Entity;

            softDelete.IsDeleted = true;
            softDelete.DeletedAt = DateTime.UtcNow;
        }
    }
}