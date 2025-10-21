using Todo.Base.Enums;
using Todo.Base.Services.DatabaseConnection;

namespace Todo.Base.Attributes;

[DataSourceType(DatasourceTypeEnum.Keyvault)]
public class KeyVaultDatabaseConnectionProvider : IDatabaseConnectionProvider
{
    public string GetConnectionString()
    {
        return "key_vault_connection_string";
    }
}