using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Core.API.Extension
{
    public static class HandlersExtension
    {
        public static void AddHandlers(this IServiceCollection service, Type interfaceKey)
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).ToList();

            var allInterfaces = allTypes
                .Where(x => !x.IsClass && x.GetInterfaces().Contains(interfaceKey)).Select(x => x).ToList();

            foreach (var interfaceType in allInterfaces)
            {
                var classe = allTypes.Where(x =>
                    x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(interfaceKey) &&
                    x.GetInterfaces().Contains(interfaceType)).Select(x => x).FirstOrDefault();

                if (classe == null)
                    continue;

                service.AddSingleton(interfaceKey, classe);
            }
        }
    }
}
