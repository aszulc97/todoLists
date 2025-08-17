using Microsoft.EntityFrameworkCore;

namespace Api.Migrations;

public static class MigrationExtenstions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        using var listsContext = serviceScope.ServiceProvider.GetRequiredService<ListsContext>();

        listsContext.Database.Migrate();
    }
}