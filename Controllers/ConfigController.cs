using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigSetting;

[ApiController]
[Route("api/[controller]")]
public class ConfigController: ControllerBase
{
    // Inject Iconfiguration  via constructors

    private IConfiguration _config;

    //Inject IOptions via constructor
    private readonly IOptions<MapApiOptions> _options;

    public ConfigController(IConfiguration config, IOptions<MapApiOptions> options)
    {
        _config =config;
        _options= options;

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
    [HttpGet("options")]
    //Endpoint: read using IOptions
        public IActionResult GetviaIOptions()
    {
        MapApiOptions info = _options.Value;

        return Ok(
                new
                {
                    Source = "IOptions",
                    info.ApiKey,
                    info.BaseUrl,
                    info.TimeoutSeconds
                }
            );


    }
}