using Microsoft.Extensions.DependencyInjection;
using Todo.App.Database;
using Todo.Base.Attributes;

namespace Todo.App.ServiceCollections;

public static class DatabaseConnectionProvider
{
    public static IServiceCollection AddDatabaseConnectionProviders(this IServiceCollection services)
    {
        services.AddSingleton<AppSettingsDatabaseConnectionProvider>();
        services.AddSingleton<KeyVaultDatabaseConnectionProvider>();

        return services;
    }
}