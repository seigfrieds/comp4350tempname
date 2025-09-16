using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace OurCity.Api.Authorization;

[ApiController]
[Route("[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly ILogger<AuthorizationController> _logger;

    public AuthorizationController(ILogger<AuthorizationController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    [Route("userInfo")]
    public Ok<List<string>> UserInformation()
    {
        return TypedResults.Ok(HttpContext.User.Claims.Select(claim => claim.Value).ToList());
    }
    
    [HttpGet]
    [Route("login")]
    public async Task<Ok> Login()
    {
        var claims = new List<Claim>();
        claims.Add(new Claim("username", new Random().Next(10).ToString()));
        var identity = new ClaimsIdentity(claims, "Cookie");
        var user = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("Cookie", user);
        
        return TypedResults.Ok();
    }
}