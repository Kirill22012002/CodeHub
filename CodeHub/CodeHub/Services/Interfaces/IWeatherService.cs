using CodeHub.ViewModels;

namespace CodeHub.Services.Interfaces
{
    public interface IWeatherService
    {
        public WeatherDataViewModel GetWeather(decimal latitude, decimal longitude);

    }
}
