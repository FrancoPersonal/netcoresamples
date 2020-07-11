# Logger Console Serilog

create a new console proyect 

```console
dotnet new console -lang "C#" -f netcoreapp3.1 --name "logger_console"
```

add dependences
```bash

Install-Package Microsoft.Extensions.DependencyInjection.Abstractions
Install-Package Microsoft.Extensions.DependencyInjection
Install-Package Microsoft.Extensions.Logging
Install-Package Microsoft.Extensions.Logging.Configuration
Install-Package Serilog.Sinks.File
Install-Package serilog.sinks.console
Install-Package Serilog.AspNetCore

# dotnet add package Serilog.AspNetCore


```

```c#
// SampleClass.cs
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
```

```c#
// SampleClass2.cs
    class SampleClass2
    {
        private readonly ILogger logger;
        const string message = "Test logger";
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
```


```c#
// Program.cs
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

```
