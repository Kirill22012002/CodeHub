using CodeHub.ViewModels;

namespace CodeHub.Services.Interfaces
{
    public interface IWeatherService
    {
        public Task<WeatherDataViewModel> GetWeather(decimal latitude, decimal longitude);
    }
}
