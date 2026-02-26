using Microsoft.AspNetCore.Mvc;
using Todo.Base.Abstractions.Services;
using Todo.Base.DTO;

namespace Todo.Main.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<TodoCollectionDTO>>> GetTodosAsync(CancellationToken cancellationToken)
    {
        var todos = await _todoService.GetAllTodosAsync(cancellationToken);
        return new OkObjectResult(todos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoCollectionDTO>> GetTodoAsync(int id, CancellationToken cancellationToken)
    {
        var todo = await _todoService.GetTodoAsync(id, cancellationToken);
        if (todo == null)
        {
            return new NotFoundResult();
        }

        return new OkObjectResult(todo);
    }
}