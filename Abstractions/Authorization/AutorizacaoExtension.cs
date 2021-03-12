//using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Abstractions.Authorization
{
    public static class AutorizacaoExtension
    {
        public static IServiceCollection ResolveAuthorization(this IServiceCollection services)
        {
            services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("User", policy =>
                {
                    policy.Requirements.Add(new UserRequirement());
                });
            });

            services.AddHandlers(typeof(IAuthorizationHandler));
            services.AddHttpContextAccessor();
            services.AddMediatR(Assembly.GetExecutingAssembly());
   
            return services;
        }
    }
}
