using Microsoft.AspNetCore.Mvc;
using WeatherAppApi.Services;

namespace WeatherAppApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private List<City> Cities = new List<City>
    {
        new City { cityName = "New York" },
        new City { cityName = "London" },
        new City { cityName = "Paris" },
        new City { cityName = "Kigali" },
        new City { cityName = "New York" },
        new City { cityName = "London" },
        new City { cityName = "Paris" },
        new City { cityName = "Kigali" }
    };

    private readonly  WeatherService _weatherService;

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<List<WeatherData>> Get()
    {
        var results = await _weatherService.GetMultiCityWeatherData(Cities);
        return results;
    }
}
