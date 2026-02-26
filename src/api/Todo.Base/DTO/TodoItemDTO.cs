namespace Todo.Base.DTO;

public class TodoItemDTO
{
    public int Id { get; set; }
    public int TodoCollectionId { get; set; }
    public int CreatedByUserId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsDeleted { get; set; }
}