using Abstractions.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Abstractions.IoC.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void RegisterDependencyInjection(this IServiceCollection service)
        {
           service.AddDependencyInjection(typeof(IService));
        }
    }
}
