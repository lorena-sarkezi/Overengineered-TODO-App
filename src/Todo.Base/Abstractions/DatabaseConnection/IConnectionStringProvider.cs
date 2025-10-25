namespace Todo.Base.Abstractions.DatabaseConnection;

public interface IConnectionStringProvider
{
    public string GetConnectionString();
}