using System.Text.Json;
using System.Threading.Tasks;
using backend.Model;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace backend.Contexts
{
    public class WeatherForecastRedisContext : IRedisContext<WeatherForecast>
    {
        private ConnectionMultiplexer _conexao;

        public WeatherForecastRedisContext(IConfiguration configuration)
        {
            _conexao = ConnectionMultiplexer.Connect(
                configuration.GetConnectionString("Redis"));
        }

        public async Task InserDataAsync(WeatherForecast value, string key)
        {
            var database = _conexao.GetDatabase();
            string data = JsonSerializer.Serialize(value);
            await database.StringSetAsync(key, data, expiry: null);
        }
    }
}