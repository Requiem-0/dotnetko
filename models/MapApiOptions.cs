namespace ConfigSetting;

public class MapApiOptions
{
    //It is a poco class
    //plain old clr object
    public string? ApiKey {get; set;}
    public string BaseUrl {get; set;} =string.Empty;
    public int TimeoutSeconds {get; set;}
}