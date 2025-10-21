using Todo.App.Attributes;
using Todo.Base.Enums;
using Todo.Base.Services.DatabaseConnection;

namespace Todo.App.Database;

[DataSourceType(DatasourceTypeEnum.AppSettings)]
public class KeyVaultDatabaseConnectionProvider : IDatabaseConnectionProvider
{
    public string GetConnectionString()
    {
        return "key_vault_connection_string";
    }
}