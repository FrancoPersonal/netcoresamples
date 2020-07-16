using Microsoft.Extensions.Configuration;

namespace CustomLoggerSample2.ConsoleApp
{
    public interface IConfigurationManager
    {
        IConfiguration BuildConfig();
    }
}