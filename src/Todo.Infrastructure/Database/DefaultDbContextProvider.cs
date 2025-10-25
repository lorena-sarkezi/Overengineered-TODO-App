using Microsoft.EntityFrameworkCore;
using Todo.Base.Abstractions.DatabaseConnection;
using Todo.Entities;

namespace Todo.Infrastructure.Database;

internal sealed class DefaultDbContextProvider : IDbContextProvider
{
    private readonly IConnectionStringProviderProviderFactory _connectionStringProviderProviderFactory;

    public DefaultDbContextProvider(IConnectionStringProviderProviderFactory connectionStringProviderProviderFactory)
    {
        _connectionStringProviderProviderFactory = connectionStringProviderProviderFactory;
    }

    public TodoAppContext GetDbContext()
    {
        var connectionString = _connectionStringProviderProviderFactory.GetConnectionStringProvider().GetConnectionString();
        var options = new DbContextOptionsBuilder<TodoAppContext>()
            .UseSqlServer(connectionString)
            .Options;
        
        return new TodoAppContext(options);
    }
}