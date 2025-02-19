using System.Text.Json;
using Janela.Data.Services.Classes;
using Microsoft.Extensions.Options;

// ReSharper disable InconsistentNaming
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Janela.Data.Services;

using System.Net.Http;
using System.Threading.Tasks;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl = "http://api.weatherapi.com/v1";

    public WeatherService(HttpClient httpClient, IOptions<ApiSettings> options)
    {
        _httpClient = httpClient;
        _apiKey = options.Value.ApiKey;
    }

    public async Task<WeatherResponse?> GetWeatherAsync(string location)
    {
        var url = $"{_baseUrl}/forecast.json?key={_apiKey}&q={location}&aqi=yes&alerts=yes&days=3";
        try
        {
            var response = await _httpClient.GetStringAsync(url);
            var decoded = JsonSerializer.Deserialize<WeatherResponse>(response);
            return decoded;
        }
        catch (Exception e)
        {
            Console.WriteLine($"The API returned an error: {e}");
            throw;
        }
    }
}

