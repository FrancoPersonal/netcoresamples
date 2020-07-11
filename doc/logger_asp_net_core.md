# Logger Asp Net Core
create a new console proyect 

```console
dotnet new webapi -lang "C#" -f netcoreapp3.1 --name "logger_console"
```

add dependences
```console

Install-Package Microsoft.Extensions.DependencyInjection.Abstractions
Install-Package Microsoft.Extensions.DependencyInjection
Install-Package Microsoft.Extensions.Logging
Install-Package Microsoft.Extensions.Logging.Configuration
Install-Package Microsoft.Extensions.Logging.Console

Install-Package Swashbuckle.AspNetCore

Install-Package Microsoft.AspNetCore.Mvc.NewtonsoftJson
Install-Package Swashbuckle.AspNetCore.Newtonsoft

Install-Package Microsoft.AspNetCore.Authentication

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
// Program.cs
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


```
