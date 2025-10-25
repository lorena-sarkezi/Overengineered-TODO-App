using Microsoft.Extensions.Options;
using Todo.Base.Abstractions.DatabaseConnection;
using Todo.Base.ApplicationOptions;
using Todo.Base.Attributes;
using Todo.Base.Enums;

namespace Todo.App.Database.ConnectionProvider.ConnectionStringProvider;

[DataSourceType(DataSourceTypeEnum.AppSettings)]
internal class AppSettingsConnectionStringProvider : IConnectionStringProvider
{
    private readonly IOptions<DatabaseOptions> _options;
    public AppSettingsConnectionStringProvider(IOptions<DatabaseOptions> options)
    {
        _options = options;
    }

    public string GetConnectionString()
    {
        return _options.Value.ConnectionString;
    }
}