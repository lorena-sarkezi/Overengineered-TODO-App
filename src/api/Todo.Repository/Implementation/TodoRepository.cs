using Microsoft.EntityFrameworkCore;
using Todo.Base.Abstractions.DatabaseConnection;
using Todo.Entities.Models;
using Todo.Repository.Contract;

namespace Todo.Repository.Implementation;

internal class TodoRepository : ITodoRepository
{
    private readonly IDbContextProvider _dbContextProvider;

    public TodoRepository(IDbContextProvider dbContextProvider)
    {
        _dbContextProvider = dbContextProvider;
    }

    public async Task<IEnumerable<TodoCollection>> GetTodosAsync(CancellationToken cancellationToken)
    {
        await using var context = await _dbContextProvider.GetDbContext();
        return await context.TodoCollections.ToListAsync(cancellationToken);
    }

    public async Task<TodoCollection> GetTodoAsync(int id, CancellationToken cancellationToken)
    {
        await using var context = await _dbContextProvider.GetDbContext();
        return await context.TodoCollections.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}