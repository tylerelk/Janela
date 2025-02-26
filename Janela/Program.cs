using Blazorise;
using Blazorise.Icons.FontAwesome;
using Blazorise.Tailwind;
using Janela.Components;
using Janela.Data;
using Janela.Data.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
Console.WriteLine($"API Key from configuration: {apiSettings?.ApiKey}");
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

builder.Services.AddSingleton<ApiService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();
//Add Weather and Location services
builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddScoped<Globals>();
//Add Blazorise
builder.Services
    .AddBlazorise()
    .AddTailwindProviders()
    .AddFontAwesomeIcons();
//Add Device detection
builder.Services.AddDetection();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public class ApiSettings
{
    public required string ApiKey { get; set; }
}

public class ApiService
{
    private readonly string _apiKey;

    public ApiService(IOptions<ApiSettings> options)
    {
        _apiKey = options.Value.ApiKey;
    }
}
