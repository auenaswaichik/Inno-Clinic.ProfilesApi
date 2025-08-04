using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

public static class MigrationExtensions
{
    public static void EnsureDatabaseMigration(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ProfilesApiDbContext>();
        db.Database.Migrate();
    }
}
