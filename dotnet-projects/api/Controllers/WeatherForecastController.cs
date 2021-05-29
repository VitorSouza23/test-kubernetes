using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRedisContext<WeatherForecast> _redisContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRedisContext<WeatherForecast> redisContext)
        {
            _logger = logger;
            _redisContext = redisContext;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _redisContext.GetAllAsync();
        }
    }
}
