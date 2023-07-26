using CodeHub.ViewModels;
using Newtonsoft.Json;

namespace CodeHub.Services
{
    public static class ParseJson
    {
        public static WeatherDataViewModel GetWeatherDataViewModels(string json)
        {
            var weather =
                JsonConvert.DeserializeObject<WeatherDataViewModel>(json);

            return weather;
        }
    }
}
