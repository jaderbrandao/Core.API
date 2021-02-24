using Core.API.Autorizacao.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Text;
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
                var httpContext = _httpContextAccessor.HttpContext;
   
                //string msg = "User Invalid.";

                var response = new AutorizationResponse()
                {
                    Message = "User Invalid."
                };
                     
                var json = JsonConvert.SerializeObject(new { response }, Formatting.None);
                var bytes = Encoding.UTF8.GetBytes(json);

                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.Body.WriteAsync(bytes, 0, json.Length);

            }

        }
    }

    public class UserRequirement : IAuthorizationRequirement { }
}
