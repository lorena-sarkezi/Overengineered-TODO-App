using System;
using System.Collections.Generic;

namespace Todo.Entities.Models;

public partial class TodoCollection
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();

    public virtual User User { get; set; } = null!;
}
