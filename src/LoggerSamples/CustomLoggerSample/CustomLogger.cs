using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLoggerSample
{
    public class CustomLogger : ILogger
    {
        public CustomLogger() { }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter
        )
        {
            var msg = formatter(state, exception);
            var json = JsonConvert.SerializeObject(new
            {
                logLevel = logLevel.ToString(),
                eventId = eventId,
                logDateTimeUtc = DateTime.UtcNow,
                details = msg,
                exception = exception
            });
            Console.WriteLine(json);
        }
    }
}
