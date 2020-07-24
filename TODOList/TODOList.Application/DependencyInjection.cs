using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TODOList.Application.Interfaces;
using TODOList.Application.Services;

namespace TODOList.Application
{
   
        public static class DependencyInjection
        {
            public static IServiceCollection AddApplication(this IServiceCollection services)
            {
                services.AddTransient<ITodoService, TodoService>();
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
                return services;
            }
        }
    
}
