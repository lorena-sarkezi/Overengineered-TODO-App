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

    public async Task<TodoAppContext> GetDbContext()
    {
        var connectionString = await _connectionStringProviderFactory.GetConnectionStringProvider().GetConnectionString();
        var options = new DbContextOptionsBuilder<TodoAppContext>()
            .UseSqlServer(connectionString)
            .Options;
        
        return new TodoAppContext(options);
    }
}