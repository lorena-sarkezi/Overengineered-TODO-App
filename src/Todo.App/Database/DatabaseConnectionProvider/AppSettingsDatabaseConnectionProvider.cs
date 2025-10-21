using Microsoft.Extensions.Options;
using Todo.Base.Abstractions.Services.DatabaseConnection;
using Todo.Base.ApplicationOptions;
using Todo.Base.Attributes;
using Todo.Base.Enums;

namespace Todo.App.Database;

[DataSourceType(DataSourceTypeEnum.AppSettings)]
public class AppSettingsDatabaseConnectionProvider : IDatabaseConnectionProvider
{
    private readonly IOptions<DatabaseOptions> _options;
    public AppSettingsDatabaseConnectionProvider(IOptions<DatabaseOptions> options)
    {
        _options = options;
    }

    public string GetConnectionString()
    {
        return _options.Value.ConnectionString;
    }
}