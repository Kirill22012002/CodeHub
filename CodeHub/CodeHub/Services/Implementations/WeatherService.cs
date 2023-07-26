using CodeHub.Services.Interfaces;
using CodeHub.ViewModels;
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
        public WeatherDataViewModel GetWeather(decimal latitude, decimal longitude)
        {
            WebRequest webRequest = 
                WebRequest.Create($"https://api.tomorrow.io/v4/timelines?location={latitude},{longitude}&fields=temperature&timesteps=1h&units=metric&apikey={_config["TomorrowWeather:SecretKey"]}");
            
            webRequest.Method = "GET";

            WebResponse webResponse = webRequest.GetResponse();

            string answer;
            using (Stream stream = webResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    answer = reader.ReadToEnd();
                }
            }
            webResponse.Close();

            var temperatureDataViewModel =
                 ParseJson.GetWeatherDataViewModels(answer);

            return temperatureDataViewModel;
        }
    }
}
