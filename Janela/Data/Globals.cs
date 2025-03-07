using Blazorise;
using Alert = Janela.Data.Services.Classes.Alert;

namespace Janela.Data;

public class Globals
{
    public static bool UseF { get; set; } = false;
    public static string? Location { get; set; }
    public static string? Condition { get; set; }
    //Hot and Cold points should be stored as C
    public static int ColdPoint { get; set; } = 7;
    public static int HotPoint { get; set; } = 27;

    public static string ForC()
    {
        var result = UseF ? "\u00b0F" : "\u00b0C";
        return result;
    }
}