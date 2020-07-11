using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace LoggerConsole.Serilog
{
    class Program
    {
        internal static void Main(string[] args)
        {
            string filelog = "consoleapp.log";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(filelog)
                .WriteTo.Console()
                .CreateLogger();

            IServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = ConfigureServices(serviceCollection);
            
            TestClass1(serviceProvider);
            TestClass2(serviceProvider);

            Console.ReadKey();
        }

        private static void TestClass1(ServiceProvider serviceProvider)
        {
            var myClass = serviceProvider.GetService<SampleClass>();
            myClass.SomeMethod();
        }


        private static void TestClass2(ServiceProvider serviceProvider)
        {
            var myClass = serviceProvider.GetService<SampleClass2>();
            myClass.SomeMethod();
        }

        /// <summary>
        /// The ConfigureServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        internal static ServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => {
                configure.AddSerilog();
            }).AddTransient<SampleClass>()
            .AddTransient<SampleClass2>();
            return services.BuildServiceProvider();
        }
    }
}
