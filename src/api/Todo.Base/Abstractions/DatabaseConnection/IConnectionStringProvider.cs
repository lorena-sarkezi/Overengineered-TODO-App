namespace Todo.Base.Abstractions.DatabaseConnection;

public interface IConnectionStringProvider
{
    public Task<string> GetConnectionString();
}