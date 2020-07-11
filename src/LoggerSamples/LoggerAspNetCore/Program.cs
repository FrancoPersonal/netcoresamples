using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LoggerAspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureLogging(logging =>
             {
                 // clear default logging providers
                 logging.ClearProviders();

                 // add built-in providers manually, as needed 
                 logging.AddConsole();
                 logging.AddDebug();
                 logging.AddEventLog();
                 logging.AddEventSourceLogger();
                 System.Diagnostics.SourceSwitch sourceSwitchName = new System.Diagnostics.SourceSwitch("test");
                 logging.AddTraceSource(sourceSwitchName);
             })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
