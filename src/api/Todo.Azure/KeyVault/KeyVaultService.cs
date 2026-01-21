using System.Collections.Concurrent;
using Todo.Base.Abstractions.Azure;

namespace Todo.Azure.KeyVault;

internal class KeyVaultService : IKeyVaultService
{
    private ConcurrentDictionary<string, string> _secretsCache = new();
    
    private readonly IKeyVaultClient _keyVaultClient;

    public KeyVaultService(IKeyVaultClient keyVaultClient)
    {
        _keyVaultClient = keyVaultClient;
    }

    public async Task<string> GetSecretValue(string key)
    {
        bool hasSecretInCache = _secretsCache.TryGetValue(key, out var cachedSecretValue);
        if (hasSecretInCache)
        {
            return cachedSecretValue!;
        }

        var keyVaultSecretValue = await _keyVaultClient.Get(key);
        _secretsCache.GetOrAdd(key, keyVaultSecretValue);
        return keyVaultSecretValue;
    }
}