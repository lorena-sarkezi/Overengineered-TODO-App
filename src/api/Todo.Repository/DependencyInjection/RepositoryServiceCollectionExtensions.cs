using Microsoft.Extensions.DependencyInjection;
using Todo.Repository.Contract;
using Todo.Repository.Implementation;

namespace Todo.Repository.DependencyInjection;

public static class RepositoryServiceCollectionExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ITodoRepository, TodoRepository>();
    }
}