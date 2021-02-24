using Core.API.Autorizacao.Response;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.API.Extension
{
    public static class HttpContextExtension
    {
        public static async Task CreateResponseAsync(this HttpContext httpContext, AutorizationResponse response)
        {
            var json = JsonConvert.SerializeObject(new { response }, Formatting.None);
            var bytes = Encoding.UTF8.GetBytes(json);

            httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.Body.WriteAsync(bytes, 0, json.Length);
        }
    }
}
