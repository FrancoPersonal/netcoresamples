using Microsoft.Extensions.Configuration;

namespace Tools.Configuration
{
    public interface IConfigurationManager
    {
        IConfiguration BuildConfig();
        IConfiguration BuildConfig(string filename);

        IConfiguration BuildConfig(string filename, string EnvironmentKey);
    }
}