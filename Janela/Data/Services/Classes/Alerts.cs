namespace Janela.Data.Services.Classes;

public class Alerts
{
    public Alert[]? alert { get; set; }
}

public class Alert
{
    public string headline { get; set; }
    public string msgtype { get; set; }
    public string severity { get; set; }
    public string urgency { get; set; }
    public string areas { get; set; }
    public string category { get; set; }
    public string certainty { get; set; }
    public string effective { get; set; }
    public string expires { get; set; }
    public string note { get; set; }
    public string desc { get; set; }
    public string instruction { get; set; }
}