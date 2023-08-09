using AccountManagementService.Dtos;
using AccountManagementService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountManagementService.Controllers;

[ApiController]
[Route("accounts/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "UserRegistration")]
    public IEnumerable<UserAccount> RegisterUser(UserAccountCreateDto userAccountCreateDto)
    {

    }
}

