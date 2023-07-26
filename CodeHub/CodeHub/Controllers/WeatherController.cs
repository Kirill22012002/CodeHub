using CodeHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CodeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult GetWeather()
        {
            var answer = _weatherService.GetWeather(54.869746M, 28.738984M); // Lepel 

            return Ok(answer);
        }
    }
}
