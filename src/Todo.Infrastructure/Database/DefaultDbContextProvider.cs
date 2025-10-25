using Microsoft.EntityFrameworkCore;
using Todo.Base.Abstractions.DatabaseConnection;
using Todo.Entities;

namespace Todo.Infrastructure.Database;

internal sealed class DefaultDbContextProvider : IDbContextProvider
{
    private readonly IConnectionStringProviderFactory _connectionStringProviderFactory;

    public DefaultDbContextProvider(IConnectionStringProviderFactory connectionStringProviderFactory)
    {
        _connectionStringProviderFactory = connectionStringProviderFactory;
    }

    public TodoAppContext GetDbContext()
    {
        var connectionString = _connectionStringProviderFactory.GetConnectionStringProvider().GetConnectionString();
        var options = new DbContextOptionsBuilder<TodoAppContext>()
            .UseSqlServer(connectionString)
            .Options;
        
        return new TodoAppContext(options);
    }
}