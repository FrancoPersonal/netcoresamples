using LoggerAspNetCore.Authentication;
using LoggerAspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerAspNetCore
{
    public class InMemoryGetApiKeyQuery : IGetApiKeyQuery
    {
        private readonly IDictionary<string, ApiKey> _apiKeys;
        string apiKeyDefaultSection = "apiKeys";


        public InMemoryGetApiKeyQuery(IConfiguration config)
        {
            var child=config.GetChildren();
            var setction = config.GetSection(apiKeyDefaultSection);
            var apiKeyTest = config.GetSection("apikeytest").Get<ApiKeyModel>();

            var existingApiKeys = config.GetSection(apiKeyDefaultSection).Get<ApiKeyModel[]>();
            _apiKeys = existingApiKeys.Select(x=>new ApiKey(x)).ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}
