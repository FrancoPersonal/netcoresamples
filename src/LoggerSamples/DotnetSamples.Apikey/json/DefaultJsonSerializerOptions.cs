using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotnetSamples.Apikey.json
{
    internal class DefaultJsonSerializerOptions
    {
        public static JsonSerializerSettings Options => new JsonSerializerSettings
        {
            ContractResolver  = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}