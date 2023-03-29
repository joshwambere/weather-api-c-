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
      

        List<Task<WeatherData?>> tasks = cities.Select( city =>
        {
            return  _httpService.Send<WeatherData>(_appSettings.OpenWeatherMapApiUrl,
                _appSettings.OpenWeatherMapApiKey, city);
            
            
        }).ToList();

        WeatherData?[] weatherData = await Task.WhenAll(tasks);

        return weatherData.ToList();
    }
}