using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerConsole.Serilog
{
    class SampleClass2
    {
        private readonly ILogger logger;
        const string message = "Test logger 2";
        public SampleClass2(ILogger<SampleClass> logger)
        {
            this.logger = logger;

        }

        internal void SomeMethod()
        {
            logger.LogInformation(message);
            logger.LogWarning(message);
            logger.LogCritical(message);
            logger.LogError(message);
            logger.LogDebug(message);
        }
    }
}
