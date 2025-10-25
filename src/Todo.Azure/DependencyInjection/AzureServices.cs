using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Azure.KeyVault;
using Todo.Base.Abstractions.Azure;

namespace Todo.Azure.DependencyInjection;

public static class AzureServices
{
    public static IServiceCollection AddAzureServices(this IServiceCollection services)
    {
        services.AddSingleton<IKeyVaultService, KeyVaultService>();
        
        return services;
    }
}