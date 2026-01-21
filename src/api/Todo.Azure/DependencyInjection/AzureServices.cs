using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Azure.KeyVault;
using Todo.Base.Abstractions.Azure;

namespace Todo.Azure.DependencyInjection;

public static class AzureServices
{
    public static void AddAzureServices(this IServiceCollection services)
    {
        services.AddSingleton<IKeyVaultService, KeyVaultService>();
    }
}