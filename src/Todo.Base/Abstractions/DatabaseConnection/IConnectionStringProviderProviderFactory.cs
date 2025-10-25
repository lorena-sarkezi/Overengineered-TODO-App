namespace Todo.Base.Abstractions.DatabaseConnection;

public interface IConnectionStringProviderProviderFactory
{
    public IConnectionStringProvider GetConnectionStringProvider();
}