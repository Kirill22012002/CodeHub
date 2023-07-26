using CodeHub.Services.Interfaces;
using CodeHub.ViewModels;
using Newtonsoft.Json;
using System.Net;

namespace CodeHub.Services.Implementations
{
    public class WeatherService : IWeatherService
    {
        private IConfiguration _config;
        public WeatherService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<WeatherDataViewModel> GetWeather(decimal latitude, decimal longitude)
        {
            HttpClient httpClient = new HttpClient();

            using var httpResponse = await httpClient.GetAsync(GetURL(latitude, longitude), HttpCompletionOption.ResponseHeadersRead);

            var weatherDataViewModel = await httpResponse.Content.ReadFromJsonAsync<WeatherDataViewModel>();

            return weatherDataViewModel;

        }

        private string GetURL(decimal latitude, decimal longitude)
        {
            return $"https://api.tomorrow.io/v4/timelines?location={latitude},{longitude}&fields=temperature&timesteps=1h&units=metric&apikey={_config["TomorrowWeather:SecretKey"]}";
        }
    }
}
