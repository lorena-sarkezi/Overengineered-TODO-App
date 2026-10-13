using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Todo.Entities;

public sealed class TodoAppContextFactory : IDesignTimeDbContextFactory<TodoAppContext>
{
    public TodoAppContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetSection("DatabaseOptions")["ConnectionString"];
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Set DatabaseOptions:ConnectionString for design-time (appsettings or environment variable).");
        }

        return new TodoAppContext(TodoAppContextOptions.Create(connectionString));
    }
}
