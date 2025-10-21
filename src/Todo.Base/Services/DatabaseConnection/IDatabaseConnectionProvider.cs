namespace Todo.Base.Services.DatabaseConnection;

public interface IDatabaseConnectionProvider
{
    public string GetConnectionString();
}