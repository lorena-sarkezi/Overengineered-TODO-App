using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Base.Abstractions.DatabaseConnection;

namespace Todo.Infrastructure.DependencyInjection;

public static class DatabaseMigration
{
    public static async Task MigrateDatabaseAsync(this IServiceProvider services)
    {
        try
        {
            await using var scope = services.CreateAsyncScope();
            var dbContextProvider = scope.ServiceProvider.GetRequiredService<IDbContextProvider>();
            await using var context = await dbContextProvider.GetDbContext();
            await context.Database.MigrateAsync();
            System.Console.WriteLine("Database migrated");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            if (ex.InnerException != null)
            {
                System.Console.WriteLine(ex.Message);
            }

            throw;
        }
        
        
    }
}
