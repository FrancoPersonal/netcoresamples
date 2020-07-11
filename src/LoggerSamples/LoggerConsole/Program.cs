namespace LoggerConsole
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;

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
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var myClass = serviceProvider.GetService<SampleClass>();
            myClass.SomeMethod();
            Console.ReadKey();
        }

        /// <summary>
        /// The ConfigureServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        internal static void ConfigureServices(IServiceCollection services) => 
            services.AddLogging(configure =>
            { 
                configure.AddConsole();
            }).AddTransient<SampleClass>();
    }
}
