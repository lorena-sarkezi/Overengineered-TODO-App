namespace Todo.Base.Abstractions.Azure;

public interface IKeyVaultClient
{
    Task<string> Get(string key);
}