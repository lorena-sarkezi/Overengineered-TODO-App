using Todo.Base.Abstractions.Services.DatabaseConnection;
using Todo.Base.Enums;

namespace Todo.Base.Attributes;

[DataSourceType(DatasourceTypeEnum.AzureKeyVault)]
public class KeyVaultDatabaseConnectionProvider : IDatabaseConnectionProvider
{
    public string GetConnectionString()
    {
        return "key_vault_connection_string";
    }
}