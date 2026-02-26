using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Services;
using Todo.Base.Abstractions.Services;

namespace Todo.Application.DependencyInjection;

public static class ServicesServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ITodoService, TodoService>();
    }
}