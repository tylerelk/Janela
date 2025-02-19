namespace Janela.Data.Services.Classes;

public class AirQuality
{
    public decimal co { get; set; }
    public decimal no2 { get; set; }
    public decimal o3 { get; set; }
    public decimal so2 { get; set; }
    public decimal pm2_5 { get; set; }
    public decimal pm10 { get; set; }
    public int us_epa_index { get; set; }
    public int gb_defra_index { get; set; }
}