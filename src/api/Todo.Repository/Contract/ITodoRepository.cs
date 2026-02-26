using Todo.Entities.Models;

namespace Todo.Repository.Contract;

public interface ITodoRepository
{
    Task<IEnumerable<TodoCollection>> GetTodosAsync(CancellationToken cancellationToken);
    Task<TodoCollection> GetTodoAsync(int id, CancellationToken cancellationToken);
}