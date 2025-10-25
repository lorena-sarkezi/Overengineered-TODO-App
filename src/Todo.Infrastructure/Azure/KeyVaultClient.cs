using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Options;
using Todo.Base.Abstractions.Azure;
using Todo.Base.ApplicationOptions;

namespace Todo.Infrastructure.Azure;

internal class KeyVaultClient : IKeyVaultClient
{
    private SecretClient  _secretClient;
    
    private readonly IOptions<KeyVaultOptions> _options;

    public KeyVaultClient(IOptions<KeyVaultOptions> options)
    {
        _options = options;
        initializeSecretClient();
    }
    
    public async Task<string> Get(string key)
    {
        var keyVaultSecret = await _secretClient.GetSecretAsync(key);

        if (!keyVaultSecret.HasValue)
        {
            throw new ArgumentNullException($"Key {key} does not exist");
        }

        return keyVaultSecret.Value.Value;
    }

    private void initializeSecretClient()
    {
        var keyVaultUrl = _options.Value.KeyVaultUrl;
        _secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
    }
}