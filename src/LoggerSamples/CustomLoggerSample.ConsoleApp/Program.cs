using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CustomLoggerSample;

using System;
using Microsoft.Extensions.Configuration;

namespace CustomLoggerSample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ILoggerFactory loggerFactory = new LoggerFactory();
            Samplelogger(ConfigureServices(serviceCollection));
            Console.ReadKey();
        }

        private static void Samplelogger(ServiceProvider serviceProvider)
        {
            var myClass = serviceProvider.GetRequiredService<SampleClass>();
            myClass.SomeMethod();
        }

        /// <summary>
        /// The ConfigureServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        internal static ServiceProvider ConfigureServices(IServiceCollection services)
        {
            var serviceProvider = services
                //.AddSingleton<IConfigurationManager, ConfigurationManager>()
                .BuildServiceProvider();

            //var configManager = serviceProvider.GetRequiredService<IConfigurationManager>();
            //var config = configManager.BuildConfig();
            //services.Add(new ServiceDescriptor(typeof(IConfiguration), config));
            services.AddLogging(configure =>
            {
                configure.AddConsole();
                  configure.AddProvider(new CustomLoggerProvider(null));
            })
                .AddTransient<SampleClass>()
                .AddSingleton<SampleClass>();
            return services.BuildServiceProvider();
        }
    }
}
