using Todo.Base.Abstractions.DatabaseConnection;
using Todo.Base.Attributes;
using Todo.Base.Enums;

namespace Todo.Infrastructure.Database.ConnectionProvider.ConnectionStringProvider;

[DataSourceType(DataSourceTypeEnum.AzureKeyVault)]
internal class KeyVaultConnectionStringProvider : IConnectionStringProvider
{
    public string GetConnectionString()
    {
        return "key_vault_connection_string";
    }
}