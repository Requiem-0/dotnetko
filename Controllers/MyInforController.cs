using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigSetting;

[ApiController]
[Route("api/[controller]")]
public class MyInfoController : ControllerBase
{
    // Inject IConfiguration
    private IConfiguration _config;

    // Inject IOptions
    private readonly IOptions<MyInfoOptions> _options;

    public MyInfoController(IConfiguration config, IOptions<MyInfoOptions> options)
    {
        _config = config;
        _options = options;
    }

    [HttpGet("iconfig")]
    public IActionResult GetViaIConfiguration()
    {
        var name = _config["MyInfo:Name"];
        var age = _config["MyInfo:Age"];
        var address = _config["MyInfo:Address"];

        return Ok(
            new
            {
                Source = "IConfiguration",
                Name = name,
                Age = age,
                Address = address
            }
        );
    }

    [HttpGet("options")]
    public IActionResult GetviaIOptions()
    {
        MyInfoOptions info = _options.Value;

        return Ok(
            new
            {
                Source = "IOptions",
                info.Name,
                info.Age,
                info.Address
            }
        );
    }
}