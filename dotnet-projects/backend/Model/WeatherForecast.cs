using System;

namespace backend.Model
{
    public class WeatherForecast
    {
        public Guid Key { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}