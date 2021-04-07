using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Threading.Tasks;

namespace Abstractions.Handlers
{
    public static class ExceptionHandler
    {
        public static async Task HandleAsync(HttpContext context, string mensagemErro, HttpStatusCode httpStatusCode)
        {
            var erro = new ResponseError { Message = mensagemErro };
            var resultado = JsonConvert.SerializeObject(erro, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            context.Response.OnStarting(async () =>
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)httpStatusCode;

                await Task.CompletedTask;
            });

            await context.Response.WriteAsync(resultado);
        }
    }

    public class ResponseError
    {
        public string Message { get; set; }
    }
}
