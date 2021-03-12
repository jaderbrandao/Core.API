using System.ComponentModel.DataAnnotations;
using System.Net;
using Abstractions.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing-V2", "Bracing-V2", "Chilly-V2", "Cool-V2", "Mild-V2", "Warm-V2", "Balmy-V2", "Hot-V2", "Sweltering-V2", "Scorching-V2"
        };

        private readonly IApiService _apiService;

        public WeatherForecastController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpPost]
        [Authorize(Policy = "User")]
        [Route("weather")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseBody))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.UnprocessableEntity, Type = typeof(ExceptionDto))]
        //[ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ExceptionDto))]
        public ActionResult<ResponseBody> Exec([FromBody] BodyRequest request)
        {
            return Ok(_apiService.Execute());
        }


        public class BodyRequest
        {
            [Required]
            public string Name { get; set; }
        }

        public class ResponseBody
        {
            public string Name { get; set; }
            public string Address { get; set; }
        }
    }
}
