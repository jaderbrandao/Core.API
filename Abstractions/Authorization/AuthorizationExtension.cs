using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Abstractions.Authorization
{
    internal static class AuthorizationExtension
    {
        internal static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
    
            return services;
        }
    }
}
