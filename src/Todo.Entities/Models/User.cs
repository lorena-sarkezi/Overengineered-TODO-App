using System;
using System.Collections.Generic;

namespace Todo.Entities.Models;

public partial class User
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<TodoCollection> TodoCollections { get; set; } = new List<TodoCollection>();

    public virtual ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
