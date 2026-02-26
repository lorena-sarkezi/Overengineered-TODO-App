using System;
using System.Collections.Generic;

namespace Todo.Entities.Models;

public partial class TodoItem
{
    public int Id { get; set; }

    public int TodoCollectionId { get; set; }

    public int UserId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TodoCollection TodoCollection { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
