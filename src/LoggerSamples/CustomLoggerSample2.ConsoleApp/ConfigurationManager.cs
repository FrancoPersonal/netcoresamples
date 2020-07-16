
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLoggerSample2.ConsoleApp
{
    public class ConfigurationManager : IConfigurationManager
    {

        public IConfiguration BuildConfig()
        {
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
              //  .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
               // .AddEnvironmentVariables();
            return config.Build();
        }
    }
}
