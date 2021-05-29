using System;
using System.Threading;
using System.Threading.Tasks;
using backend.Contexts;
using backend.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace backend
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRedisContext<WeatherForecast> _redisContext;
        private readonly Random _random;

        public Worker(ILogger<Worker> logger, IRedisContext<WeatherForecast> redisContext)
        {
            _logger = logger;
            _redisContext = redisContext;
            _random = new Random();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await InsertNewData();
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private async Task InsertNewData()
        {
            WeatherForecast weatherForecast = new()
            {
                Date = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                Summary = $"Sample nº {DateTime.UtcNow.Ticks}",
                TemperatureC = _random.Next(100)
            };

            await _redisContext.InserDataAsync(weatherForecast, weatherForecast.Id.ToString());
            _logger.LogInformation($"Key {weatherForecast.Id} inserted");
        }
    }
}
