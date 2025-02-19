namespace Janela.Data.Services;

using Microsoft.JSInterop;
using System.Text.Json;

// ReSharper disable InconsistentNaming
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

using System.Net.Http;
using System.Threading.Tasks;

public class LocationService : ILocationService
{
    private IJSRuntime JsRuntime { get; set; }
    private readonly HttpClient _httpClient;
    private const string unsplashUrl = "https://api.unsplash.com/search/photos";
    private const string unsplashApiKey = "d7vCbZG154AqXv-WxG7vHYVsMQMsH9P3O3qsd9iUygk";
    
    public LocationService(IJSRuntime jsRuntime, HttpClient httpClient)
    {
        JsRuntime = jsRuntime;
        _httpClient = httpClient;
    }
    
    public async Task<Coordinates> GetCurrentLocation()
    {
        var location = await JsRuntime.InvokeAsync<Coordinates>("getGeolocation");
        return location;
    }

    public async Task<string?> GetLocationImageUrl(string location)
    {
        var url = $"{unsplashUrl}?client_id={unsplashApiKey}&orientation=landscape&per_page=1&query={location}";
        try
        {
            _httpClient.DefaultRequestHeaders.Add("Accept-Version", "v1");
            var rawUrl = "";
            var response = await _httpClient.GetStringAsync(url);
            var decoded = JsonSerializer.Deserialize<JsonElement>(response);
            if (decoded.TryGetProperty("results", out var results) && results[0].TryGetProperty("urls", out var urls))
            {
                rawUrl = urls.GetProperty("raw").GetString();
            }

            return rawUrl;
        }
        catch (Exception e)
        {
            Console.WriteLine($"The API returned an error: {e}");
        }
        return null;
    }
}

public class Coordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}