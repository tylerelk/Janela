namespace Janela.Data.Services.Classes;

public class Current
{
    public decimal temp_c { get; set; }
    public decimal temp_f { get; set; }
    public decimal feelslike_c { get; set; }
    public decimal feelslike_f { get; set; }
    public decimal windchill_c { get; set; }
    public decimal windchill_f { get; set; }
    public decimal heatindex_c { get; set; }
    public decimal heatindex_f { get; set; }
    public decimal dewpoint_c { get; set; }
    public decimal dewpoint_f { get; set; }
    public Condition condition { get; set; }
    public decimal wind_mph { get; set; }
    public decimal wind_kph { get; set; }
    public int wind_degree { get; set; }
    public string wind_dir { get; set; }
    public decimal pressure_mb { get; set; }
    public decimal pressure_in { get; set; }
    public decimal precip_mm { get; set; }
    public decimal precip_in { get; set; }
    public int humidity { get; set; }
    public int cloud { get; set; }
    public int is_day { get; set; }
    public decimal uv { get; set; }
    public decimal gust_mph { get; set; }
    public decimal gust_kph { get; set; }
}