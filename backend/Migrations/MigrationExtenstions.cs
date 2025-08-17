using Microsoft.EntityFrameworkCore;

namespace Api.Migrations;

public static class MigrationExtenstions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
        using ListsContext listsContext = serviceScope.ServiceProvider.GetRequiredService<ListsContext>();

        listsContext.Database.Migrate();
    }
}