namespace Janela.Data.Services.Classes;

public class Forecast
{
    public List<ForecastDay> forecastday { get; set; }
}

public class ForecastDay
{
    public string date { get; set; }
    public long date_epoch { get; set; }
    public Day day { get; set; }
    public Astro astro { get; set; }
    public List<Hour> hour { get; set; }
}