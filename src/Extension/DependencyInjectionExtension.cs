using APICore.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Swagger_Versioning.Extension
{
    public static class DependencyInjectionExtension
    {
        public static void RegisterDependencyInjection(this IServiceCollection service)
        {
            service.AddDependencyInjection(typeof(IService));
        }
    }
}
