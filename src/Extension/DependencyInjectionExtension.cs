using APICore.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Core.API.Extension
{
    public static class DependencyInjectionExtension
    {
        public static void RegisterDependencyInjection(this IServiceCollection service)
        {
            service.AddDependencyInjection(typeof(IService));
        }
    }
}
