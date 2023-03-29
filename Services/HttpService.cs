namespace WeatherAppApi.Services;

public class HttpService
{
    private readonly  HttpClient _httpClient = new();
    private ILogger<HttpService> _logger;


    public HttpService(ILogger<HttpService> logger)
    {
        _logger = logger;
    }

    public async Task<T?> Send<T>(string url, string apiKey, City city)
    {
        try
        {
            var uri = $"{url}?q={city.cityName}&appid={apiKey}";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("x-api-key", apiKey);
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return default;
            }
            return  await response.Content.ReadFromJsonAsync<T>();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while sending http request");
            throw;
        }
    }
}