namespace Todo.Base.Abstractions.Services.DatabaseConnection;

public interface IDatabaseConnectionProviderFactory
{
    public IDatabaseConnectionProvider GetDatabaseConnectionProvider();
}