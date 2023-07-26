using CodeHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CodeHub.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather()
        {
            var answer = await _weatherService.GetWeather(54.869746M, 28.738984M); // Lepel 
            return Ok(answer);
        }
    }
}
