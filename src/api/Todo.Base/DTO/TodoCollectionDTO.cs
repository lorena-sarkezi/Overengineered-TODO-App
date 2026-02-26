using Todo.Entities.Models;

namespace Todo.Base.DTO;

public class TodoCollectionDTO
{
    public int Id { get; set; }
    public int CreatedByUserId { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedOn { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsDeleted { get; set; }
    public IEnumerable<TodoItemDTO> TodoItems { get; set; } = new List<TodoItemDTO>();
}

public static class TodoCollectionDTOExtensions
{
    public static TodoCollectionDTO ToDTO(this TodoCollection todoCollection)
    {
        return new TodoCollectionDTO
        {
            Id = todoCollection.Id,
            CreatedByUserId = todoCollection.UserId,
            Name = todoCollection.Name,
            CreatedOn = todoCollection.CreatedOn,
            IsCompleted = todoCollection.IsCompleted,
            IsDeleted = todoCollection.IsDeleted,
            TodoItems = todoCollection.TodoItems.Select(ti => new TodoItemDTO
            {
                Id = ti.Id,
                TodoCollectionId = ti.TodoCollectionId,
                CreatedByUserId = ti.UserId,
                Text = ti.Text,
                CreatedOn = ti.CreatedOn,
                IsCompleted = ti.IsCompleted,
                IsDeleted = ti.IsDeleted
            }).ToList()
        };
    }
}