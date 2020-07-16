using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLoggerSample2
{
    public class ColoredConsoleLoggerConfiguration
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;
        [JsonConverter(typeof(StringEnumConverter))]
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
    }
}
