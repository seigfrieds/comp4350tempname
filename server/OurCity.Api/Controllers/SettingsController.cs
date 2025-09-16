using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OurCity.Api.Configurations;

namespace OurCity.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SettingsController : ControllerBase
{
    private readonly ILogger<SettingsController> _logger;
    private readonly IOptions<ExampleSettings> _exampleSettings;

    public SettingsController(ILogger<SettingsController> logger, IOptions<ExampleSettings> exampleSettings)
    {
        _logger = logger;
        _exampleSettings = exampleSettings;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("I am processing a Settings request right now!");

        return Ok(_exampleSettings.Value);
    }
}