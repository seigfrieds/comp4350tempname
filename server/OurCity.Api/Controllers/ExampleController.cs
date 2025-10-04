using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OurCity.Api.Configurations;
using OurCity.Api.Services;

namespace OurCity.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    private readonly ILogger<ExampleController> _logger;
    private readonly IOptions<ExampleSettings> _exampleSettings;
    private readonly IPostService _postService;
    
    public ExampleController(
        IPostService postService, 
        IOptions<ExampleSettings> exampleSettings, 
        ILogger<ExampleController> logger
    )
    {
        _postService = postService;
        _exampleSettings = exampleSettings;
        _logger = logger;
    }

    [HttpGet]
    [Route("Posts")]
    public async Task<IActionResult> GetPosts()
    {
        var posts = (await _postService.GetPosts()).ToList();
        
        return Ok(posts);
    }
    
    [HttpGet]
    [Route("Settings")]
    public IActionResult GetSettings()
    {
        _logger.LogInformation("I am processing a Settings request right now!");

        return Ok(_exampleSettings.Value);
    }
    
    [HttpGet]
    [Route("WeatherForecast")]
    public IActionResult GetWeatherForecast(
        [Required] [FromQuery(Name = "fail")] bool fail
    )
    {
        _logger.LogInformation("I am processing a WeatherForecast request right now!");

        if (fail)
        {
            _logger.LogError("Weather forecast does not exist brah");
            
            return Problem(
                statusCode: StatusCodes.Status404NotFound, 
                detail: "Weather forecast does not exist"
            );
        }

        return Ok(
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList()
        );
    }
}

class WeatherForecast
{
    public DateOnly Date { get; set;  }

    public int TemperatureC { get; set;  }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set;  }
}