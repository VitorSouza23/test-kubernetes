using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using test_kubernetes.Models;

namespace test_kubernetes.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ILogger<WeatherForecastService> _logger;
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient, ILogger<WeatherForecastService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAll()
        {
            _logger.LogInformation("Fetch data...");
            var response = await _httpClient.GetAsync("/WeatherForecast");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(responseString);
        }
    }
}