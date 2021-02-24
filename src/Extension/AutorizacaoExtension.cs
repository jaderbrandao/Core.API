using APICore.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Swagger_Versioning.Core.API;

namespace Swagger_Versioning.Extension
{
    public static class AutorizacaoExtension
    {
        public static void ResolveAuthorization(this IServiceCollection service)
        {
            service.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy =>
                {
                    policy.Requirements.Add(new UserRequirement());
                });
            });

            service.AddScoped<IAuthorizationHandler, AutorizacaoHandler>();
            service.AddMediatR(typeof(AutorizacaoHandler));
            service.AddHttpContextAccessor();
        }
    }
}
