using System.Collections.Generic;
using System.Threading.Tasks;
using test_kubernetes.Models;

namespace test_kubernetes.Services
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetAll();
    }
}