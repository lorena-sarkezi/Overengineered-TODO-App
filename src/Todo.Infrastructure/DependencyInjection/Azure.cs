using Microsoft.Extensions.DependencyInjection;
using Todo.Base.Abstractions.Azure;
using Todo.Infrastructure.Azure;

namespace Todo.Infrastructure.DependencyInjection;

public static class Azure
{
    public static void AddAzureInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IKeyVaultClient, KeyVaultClient>();
    }
}