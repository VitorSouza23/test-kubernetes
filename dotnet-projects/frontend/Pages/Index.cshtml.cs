using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using test_kubernetes.Models;
using test_kubernetes.Services;

namespace test_kubernetes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public IEnumerable<WeatherForecast> WeatherForecasts { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        public async Task OnGet()
        {
            WeatherForecasts = await _weatherForecastService.GetAll();
        }
    }
}
