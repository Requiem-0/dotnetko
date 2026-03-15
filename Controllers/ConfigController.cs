using Microsoft.AspNetCore.Mvc;

namespace ConfigSetting;

[ApiController]
[Route("api/[controller]")]
public class ConfigController: ControllerBase
{
    // Inject Iconfiguration  via constructors

    private IConfiguration _config;
    public ConfigController(IConfiguration config)
    {
        _config =config;
    }

    //Endpoint : read using  IConfiguration

    [HttpGet("iconfig")]
    public IActionResult GetViaIConfiguration()
    {
        var apiKey = _config["MapApiSetting:ApiKey"];
        var baseUrl = _config["MapApiSetting:BaseUrl"];
        var timeOut = _config["MapApiSetting:TimeoutSeconds"];

        return Ok(
            new
            {
                Source ="IConfiguration",
                ApiKey=apiKey,
                BaseUrl= baseUrl,
                TimeoutSeconds= timeOut,
                
            }
        );
    }
}