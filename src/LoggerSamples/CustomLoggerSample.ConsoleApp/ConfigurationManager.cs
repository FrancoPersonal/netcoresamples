using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLoggerSample.ConsoleApp
{
    public class ConfigurationManager : IConfigurationManager
    {
        public IConfiguration BuildConfig()
        {
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
             //   .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();
            return config.Build();
        }
    }
}
