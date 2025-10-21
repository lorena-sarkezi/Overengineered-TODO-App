using Microsoft.Extensions.Options;
using Todo.App.ApplicationOptions;
using Todo.Base.Attributes;
using Todo.Base.Enums;
using Todo.Base.Services.DatabaseConnection;

namespace Todo.App.Database;

[DataSourceType(DatasourceTypeEnum.AppSettings)]
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