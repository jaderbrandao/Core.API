using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Swagger_Versioning.Controllers.v2.WeatherForecastController;

namespace Swagger_Versioning.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated =true)]
    [Route("v{version:apiVersion}")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("weather")]
        public ActionResult<ResponseBody> Exec([FromBody] BodyRequest request)
        {
            return Ok(new ResponseBody { Name = request.Name, Address = "Maracanã" });
        }

    }
}
