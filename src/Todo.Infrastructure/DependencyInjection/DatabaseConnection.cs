using Microsoft.Extensions.DependencyInjection;
using Todo.Base.Abstractions.DatabaseConnection;
using Todo.Infrastructure.Database;
using Todo.Infrastructure.Database.ConnectionProvider;
using Todo.Infrastructure.Database.ConnectionProvider.ConnectionStringProvider;

namespace Todo.Infrastructure.DependencyInjection;

public static class DatabaseConnection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddSingleton<IConnectionStringProvider, AppSettingsConnectionStringProvider>();
        services.AddSingleton<IConnectionStringProvider, KeyVaultConnectionStringProvider>();
        
        services.AddTransient<IConnectionStringProviderProviderFactory, ConnectionStringProviderProviderFactory>();
        services.AddTransient<IDbContextProvider, DefaultDbContextProvider>();
        
        return services;
    }
}