using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Options;
using Todo.Base.Abstractions.Services.DatabaseConnection;
using Todo.Base.ApplicationOptions;
using Todo.Base.Attributes;
using Todo.Base.Enums;

namespace Todo.App.Database;

public class DatabaseConnectionProviderFactory : IDatabaseConnectionProviderFactory
{
    private readonly Dictionary<DataSourceTypeEnum, IDatabaseConnectionProvider> _providersMapping;
    
    private readonly IOptions<DataSourceSettings> _dataSourceSettings;
    private readonly IEnumerable<IDatabaseConnectionProvider> _databaseConnectionProviders;

    public DatabaseConnectionProviderFactory(
        IOptions<DataSourceSettings> dataSourceSettings, 
        IEnumerable<IDatabaseConnectionProvider> databaseConnectionProviders)
    {
        _dataSourceSettings = dataSourceSettings;
        _databaseConnectionProviders = databaseConnectionProviders;
        
        _providersMapping = new Dictionary<DataSourceTypeEnum, IDatabaseConnectionProvider>();
        ensureDataSourceConnectionProviders();
    }

    public IDatabaseConnectionProvider GetDatabaseConnectionProvider()
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