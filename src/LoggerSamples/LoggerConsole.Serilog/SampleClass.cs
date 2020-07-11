using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerConsole.Serilog
{
    class SampleClass
    {
        private readonly ILogger logger;
        const string message = "Test logger";
        public SampleClass(ILogger<SampleClass> logger)
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

