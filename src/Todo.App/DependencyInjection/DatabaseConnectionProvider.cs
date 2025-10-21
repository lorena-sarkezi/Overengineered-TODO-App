using Microsoft.Extensions.DependencyInjection;
using Todo.App.Database;
using Todo.Base.Abstractions.Services.DatabaseConnection;
using Todo.Base.Attributes;

namespace Todo.App.DependencyInjection;

public static class DatabaseConnectionProvider
{
    public static IServiceCollection AddDatabaseConnectionProviders(this IServiceCollection services)
    {
        services.AddSingleton<IDatabaseConnectionProvider, AppSettingsDatabaseConnectionProvider>();
        services.AddSingleton<IDatabaseConnectionProvider, KeyVaultDatabaseConnectionProvider>();
        services.AddSingleton<IDatabaseConnectionProviderFactory, DatabaseConnectionProviderFactory>();
        
        return services;
    }
}