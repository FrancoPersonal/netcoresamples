using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace LoggerAspNetCore
{
 
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
