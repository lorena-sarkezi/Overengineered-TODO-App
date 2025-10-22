using Todo.Base.Abstractions.Services.DatabaseConnection;
using Todo.Base.Attributes;
using Todo.Base.Enums;

namespace Todo.App.Database.DatabaseConnectionProvider;

[DataSourceType(DataSourceTypeEnum.AzureKeyVault)]
internal class KeyVaultDatabaseConnectionProvider : IDatabaseConnectionProvider
{
    public string GetConnectionString()
    {
        return "key_vault_connection_string";
    }
}