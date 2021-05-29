using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace api.Contexts
{
    public class WeatherForecastRedisContext : IRedisContext<WeatherForecast>
    {
        private ConnectionMultiplexer _conexao;

        public WeatherForecastRedisContext(IConfiguration configuration)
        {
            _conexao = ConnectionMultiplexer.Connect(
                configuration.GetConnectionString("Redis"));
        }

        public async Task<WeatherForecast> GetDataAsync(string key)
        {
            var database = _conexao.GetDatabase();
            var data = await database.StringGetAsync(key);
            return JsonSerializer.Deserialize<WeatherForecast>(data);
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllAsync()
        {
            var endpoint = _conexao.GetEndPoints().FirstOrDefault();
            var database = _conexao.GetDatabase();
            var keys = _conexao.GetServer(endpoint).Keys();
            List<string> values = new();
            foreach (var key in keys)
            {
                values.Add(await database.StringGetAsync(key));
            }
            return values.Select(v => JsonSerializer.Deserialize<WeatherForecast>(v));
        }
    }
}