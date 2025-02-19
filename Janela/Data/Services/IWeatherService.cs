using Janela.Data.Services.Classes;

namespace Janela.Data.Services;

public interface IWeatherService
{
    Task<WeatherResponse?> GetWeatherAsync(string location);
}