using Core.API.Autorizacao.Response;
using Core.API.Extension;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Core.API.Autorizacao
{
    public class AutorizacaoHandler : AuthorizationHandler<UserRequirement>
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AutorizacaoHandler(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
        {
            //Get Validation Service
            var access = await Task.FromResult(false);
                      

            if (access)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
                await _httpContextAccessor.HttpContext.CreateResponseAsync(new AutorizationResponse() { Message = "User Invalid." });
            }

        }
    }

    public class UserRequirement : IAuthorizationRequirement { }
}
