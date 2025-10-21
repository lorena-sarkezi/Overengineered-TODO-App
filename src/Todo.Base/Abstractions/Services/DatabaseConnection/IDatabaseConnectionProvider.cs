namespace Todo.Base.Abstractions.Services.DatabaseConnection;

public interface IDatabaseConnectionProvider
{
    public string GetConnectionString();
}