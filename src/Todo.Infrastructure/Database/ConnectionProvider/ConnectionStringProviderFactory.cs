using System.Reflection;
using Microsoft.Extensions.Options;
using Todo.Base.Abstractions.DatabaseConnection;
using Todo.Base.ApplicationOptions;
using Todo.Base.Attributes;
using Todo.Base.Enums;

namespace Todo.Infrastructure.Database.ConnectionProvider;

internal class ConnectionStringProviderFactory : IConnectionStringProviderFactory
{
    private readonly Dictionary<DataSourceTypeEnum, IConnectionStringProvider> _providersMapping;
    
    private readonly IOptions<DataSourceSettings> _dataSourceSettings;
    private readonly IEnumerable<IConnectionStringProvider> _databaseConnectionProviders;

    public ConnectionStringProviderFactory(
        IOptions<DataSourceSettings> dataSourceSettings, 
        IEnumerable<IConnectionStringProvider> databaseConnectionProviders)
    {
        _dataSourceSettings = dataSourceSettings;
        _databaseConnectionProviders = databaseConnectionProviders;
        
        _providersMapping = new Dictionary<DataSourceTypeEnum, IConnectionStringProvider>();
        ensureDataSourceConnectionProviders();
    }

    public IConnectionStringProvider GetConnectionStringProvider()
    {
        var currentDataSourceSetting = Enum.Parse<DataSourceTypeEnum>(_dataSourceSettings.Value.ConnectionStringSource);
        return _providersMapping[currentDataSourceSetting];
    }

    private void ensureDataSourceConnectionProviders()
    {
        foreach (var provider in _databaseConnectionProviders)
        {
            var attr = provider.GetType().GetCustomAttribute<DataSourceTypeAttribute>();
            if (attr == null)
            {
                throw new ArgumentNullException($"{provider} does not have a DataSourceTypeAttribute");
            }
            var dataSourceType = attr.DatabaseDataSourceType;
            _providersMapping.Add(dataSourceType, provider);
        }
    }
}