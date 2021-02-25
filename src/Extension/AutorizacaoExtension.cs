using Core.API.Autorizacao;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Core.API.Extension
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

            service.AddHandlers(typeof(IAuthorizationHandler));
            service.AddHttpContextAccessor();
        }
    }
}
