namespace CodeHub.Services.Interfaces
{
    public interface IWeatherService
    {
        public void GetWeather(decimal latitude, decimal longitude);

    }
}
