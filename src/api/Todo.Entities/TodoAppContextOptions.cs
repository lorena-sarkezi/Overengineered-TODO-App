using Microsoft.EntityFrameworkCore;

namespace Todo.Entities;

public static class TodoAppContextOptions
{
    public static DbContextOptions<TodoAppContext> Create(string connectionString)
        => new DbContextOptionsBuilder<TodoAppContext>()
            .UseNpgsql(connectionString)
            .Options;
}
