using Microsoft.Extensions.DependencyInjection;
using Todo.App.Database;
using Todo.App.Database.ConnectionProvider;
using Todo.App.Database.ConnectionProvider.ConnectionStringProvider;
using Todo.Base.Abstractions.DatabaseConnection;
using Todo.Base.Attributes;

namespace Todo.App.DependencyInjection;

public static class DatabaseConnectionProvider
{
    public static IServiceCollection AddDatabaseConnectionProviders(this IServiceCollection services)
    {
        services.AddSingleton<IConnectionStringProvider, AppSettingsConnectionStringProvider>();
        services.AddSingleton<IConnectionStringProvider, KeyVaultConnectionStringProvider>();
        
        services.AddTransient<IConnectionStringProviderProviderFactory, ConnectionStringProviderProviderFactory>();
        services.AddTransient<IDbContextProvider, DefaultDbContextProvider>();
        
        return services;
    }
}