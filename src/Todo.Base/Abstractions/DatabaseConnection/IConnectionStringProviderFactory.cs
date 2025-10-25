namespace Todo.Base.Abstractions.DatabaseConnection;

public interface IConnectionStringProviderFactory
{
    public IConnectionStringProvider GetConnectionStringProvider();
}