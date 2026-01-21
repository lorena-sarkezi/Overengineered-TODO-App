using Todo.Entities;

namespace Todo.Base.Abstractions.DatabaseConnection;

public interface IDbContextProvider
{
    public Task<TodoAppContext> GetDbContext();
}