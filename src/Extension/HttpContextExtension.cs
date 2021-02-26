using Core.API.Autorizacao.Response;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
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

        public static async Task CreateResponseMessageAsync(this HttpContext httpContext)
        {
            string message = "Forbidden access";
            var bytes = Encoding.UTF8.GetBytes(message);

            httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.Body.WriteAsync(bytes, 0, message.Length);



            //using var memoryStream = new MemoryStream();
            //var stream = httpResponse.Body;
            //httpResponse.Body = memoryStream;

            //string message = "Forbidden access";

            //httpResponse.StatusCode = (int)HttpStatusCode.Forbidden;
            //httpResponse.ContentType = "application/json";

            //var json = JsonConvert.SerializeObject(new { message }, Formatting.None);
            //var bytes = Encoding.UTF8.GetBytes(message);

            //await stream.WriteAsync(bytes);
            //await stream.FlushAsync();
        }
    }
}
