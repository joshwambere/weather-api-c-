using Microsoft.Extensions.Options;
using WeatherAppApi.Settings;

namespace WeatherAppApi.Services;

public class WeatherService
{
    private readonly HttpService _httpService;
    private readonly AppSettings _appSettings;
    public WeatherService(HttpService httpService, IOptions<AppSettings> appSettings)
    {
        _httpService = httpService;
        _appSettings = appSettings.Value;
    }

    public async Task<List<WeatherData>> GetMultiCityWeatherData(List<City> cities )
    {
        List<WeatherData> weatherData = new();
        
        foreach (var city in cities)
        {
            Console.WriteLine(_appSettings.OpenWeatherMapApiKey);
            var result = await _httpService.Send<WeatherData>(_appSettings.OpenWeatherMapApiUrl,
                _appSettings.OpenWeatherMapApiKey, city);
            if (result!=null)
            {
                weatherData.Add(result);
            }
        }

        return weatherData;
    }
}