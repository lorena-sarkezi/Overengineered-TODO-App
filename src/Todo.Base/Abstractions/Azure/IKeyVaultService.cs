namespace Todo.Base.Abstractions.Azure;

public interface IKeyVaultService
{
    Task<string> GetSecretValue(string key);
}