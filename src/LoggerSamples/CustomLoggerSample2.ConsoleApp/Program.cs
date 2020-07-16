namespace CustomLoggerSample2.ConsoleApp
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using Tools.Configuration;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        internal static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            Samplelogger(ConfigureServices(serviceCollection));
            Console.ReadKey();
        }

        /// <summary>
        /// The Samplelogger.
        /// </summary>
        /// <param name="serviceProvider">The serviceProvider<see cref="ServiceProvider"/>.</param>
        private static void Samplelogger(ServiceProvider serviceProvider)
        {
            var myClass = serviceProvider.GetRequiredService<SampleClass>();
            myClass.SomeMethod();
        }

        /// <summary>
        /// The ConfigureServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="ServiceProvider"/>.</returns>
        internal static ServiceProvider ConfigureServices(IServiceCollection services)
        {
            var serviceProvider = services
                .AddSingleton<IConfigurationManager, ConfigurationManager>()
                .BuildServiceProvider();

            var configManager = serviceProvider.GetRequiredService<IConfigurationManager>();
            var config = configManager.BuildConfig();
            services.Add(new ServiceDescriptor(typeof(IConfiguration), config));
            var provider = services
                .AddOptions()
                .Configure<ColoredConsoleLoggerConfiguration>(config.GetSection(nameof(ColoredConsoleLoggerConfiguration)))
                .AddSingleton<ColoredConsoleLoggerProvider>()
                .BuildServiceProvider();

            services.AddLogging(configure =>
            {
                configure.AddConsole();
                configure.AddProvider(provider.GetRequiredService<ColoredConsoleLoggerProvider>());
            })
                .AddTransient<SampleClass>();
            return services.BuildServiceProvider();
        }
    }
}
