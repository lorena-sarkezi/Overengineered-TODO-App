using Todo.Base.DTO;

namespace Todo.Base.Abstractions.Services;

public interface ITodoService
{
    Task<IEnumerable<TodoCollectionDTO>> GetAllTodosAsync(CancellationToken cancellationToken);
    Task<TodoCollectionDTO> GetTodoAsync(int id, CancellationToken cancellationToken);
}