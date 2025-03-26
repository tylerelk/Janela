using System.Runtime.CompilerServices;
using Blazorise;
using Alert = Janela.Data.Services.Classes.Alert;
using Wangkanai.Detection.Services;

namespace Janela.Data;

public class Globals
{
    public static bool UseF { get; set; } = false;
    public static string? Location { get; set; }
    public static string? Condition { get; set; }
    //Hot and Cold points should be stored as C
    public static int ColdPoint { get; set; } = 7;
    public static int HotPoint { get; set; } = 27;
    public static Dictionary<string, string> BgImageUrls { get; set; } = new();
    public static bool IsMobile { get; set; }

    //Utility to show correct units based on user preference
    public static string ForC()
    {
        var result = UseF ? "\u00b0F" : "\u00b0C";
        return result;
    }
    
    //This method run at page load via Home.razor to set mobile detection
    public static void detectMobile(bool isMobile)
    {
        IsMobile = isMobile;
    }
}