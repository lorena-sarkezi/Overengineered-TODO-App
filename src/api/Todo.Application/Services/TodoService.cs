using Todo.Base.Abstractions.Services;
using Todo.Base.DTO;
using Todo.Repository.Contract;

namespace Todo.Application.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
    
    public async Task<IEnumerable<TodoCollectionDTO>> GetAllTodosAsync(CancellationToken cancellationToken)
    {
        var results = await _todoRepository.GetTodosAsync(cancellationToken);
        return results.Select(x => x.ToDTO());
    }

    public async Task<TodoCollectionDTO> GetTodoAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _todoRepository.GetTodoAsync(id, cancellationToken);
        return result.ToDTO();
    }
}