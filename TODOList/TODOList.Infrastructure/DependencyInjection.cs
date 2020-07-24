using Microsoft.Extensions.DependencyInjection;
using TODOList.Domain.Interfaces;
using TODOList.Infrastructure.Repositories;

namespace TODOList.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITodoItemRepository, TodoItemRepository>();
            services.AddTransient<ITodoListRepository, TodoListRepository>();
            return services;
        }
    }
}
