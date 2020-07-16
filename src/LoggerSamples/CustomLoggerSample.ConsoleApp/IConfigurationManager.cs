using Microsoft.Extensions.Configuration;

namespace CustomLoggerSample.ConsoleApp
{
    public interface IConfigurationManager
    {
        IConfiguration BuildConfig();
    }
}