using Core.API.Autorizacao.Commands.User;
using Core.API.Autorizacao.Response;
using Core.API.Extension;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace Core.API.Autorizacao
{
    public class UserAuthorizationHandler : AutorizacaoHandler<UserRequirement>
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAuthorizationHandler(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
        {
            //Get URI values
            var userCodeRoute = (string)_httpContextAccessor.HttpContext.GetRouteValue("UserCode");

            //Get Header values
            _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("UserCode", out var userCodeHeader);
                   
            //Get Query values
            var userCodeQuery = (string)_httpContextAccessor.HttpContext.Request.Query["UserCodeQuery"];


            var autorizacao = await _mediator.Send(new UserRequest() { User = "Jader", Password = "123" });

            if (autorizacao.Autorizado)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
               // await _httpContextAccessor.HttpContext.CreateResponseAsync(new AutorizationResponse() { Message = "User Invalid." });
               await _httpContextAccessor.HttpContext.CreateResponseMessageAsync();
            }

        }
    }

    public class UserRequirement : IAuthorizationRequirement { }
}
