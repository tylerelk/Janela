namespace Janela.Data.Services;

public interface ILocationService
{
    public Task<Coordinates> GetCurrentLocation();
    public Task<string?> GetLocationImageUrl(string location);
}