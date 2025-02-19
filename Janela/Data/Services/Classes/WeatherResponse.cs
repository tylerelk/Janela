namespace Janela.Data.Services.Classes;

public class WeatherResponse
{
    public Location location { get; set; }
    public Current current { get; set; }
    public Forecast forecast { get; set; }
    public Alerts alerts { get; set; }
}