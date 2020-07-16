
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        const string defaultEnvironmentKey = "Hosting:Environment";
        const string defaultFileNameConfig = "appsettings";


        public IConfiguration BuildConfig()
        {
            return BuildConfig(defaultFileNameConfig, defaultEnvironmentKey);
        }

        public IConfiguration BuildConfig(string filename)
        {
            return BuildConfig(filename, defaultEnvironmentKey);
        }

        public IConfiguration BuildConfig(string filename, string EnvironmentKey)
        {
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");

            var config = new ConfigurationBuilder()
                .AddJsonFile($"{filename}.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{filename}.{environmentName}.json", optional: true)
                .AddEnvironmentVariables();
            return config.Build();
        }
    }
}
