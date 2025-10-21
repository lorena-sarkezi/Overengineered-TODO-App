using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Todo.App.ApplicationOptions;

namespace Todo.Base.ServiceCollections;

public static class ApplicationOptions
{
    public static IServiceCollection AddDatabaseOptions(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        serviceCollection.Configure<DataSourceSettings>(configurationManager.GetSection(nameof(DataSourceSettings)));
        serviceCollection.Configure<DatabaseOptions>(configurationManager.GetSection(nameof(DatabaseOptions)));

        return serviceCollection;
    }
}