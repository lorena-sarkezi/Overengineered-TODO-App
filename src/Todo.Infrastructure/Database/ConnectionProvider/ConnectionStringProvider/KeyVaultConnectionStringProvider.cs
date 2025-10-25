using Todo.Base;
using Todo.Base.Abstractions.Azure;
using Todo.Base.Abstractions.DatabaseConnection;
using Todo.Base.Attributes;
using Todo.Base.Enums;

namespace Todo.Infrastructure.Database.ConnectionProvider.ConnectionStringProvider;

[DataSourceType(DataSourceTypeEnum.AzureKeyVault)]
internal class KeyVaultConnectionStringProvider : IConnectionStringProvider
{
    private readonly IKeyVaultService _keyVaultService;

    public KeyVaultConnectionStringProvider(IKeyVaultService keyVaultService)
    {
        _keyVaultService = keyVaultService;
    }
    
    public string GetConnectionString()
    {
        return _keyVaultService.GetSecretValue(AppConstants.KeyVaultConnectionStringKey).GetAwaiter().GetResult();
    }
}