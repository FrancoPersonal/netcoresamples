﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLoggerSample2.ConsoleApp
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
            logger.LogInformation(message + "LogInformation");
            logger.LogWarning(message + "LogWarning");
            logger.LogCritical(message + "LogCritical");
            logger.LogError(message + "LogError");
            logger.LogDebug(message + "LogDebug");
        }
    }
}
