﻿using DotnetSamples.Apikey.Authorization;
using LoggerAspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerAspNetCore
{
    public class InMemoryGetApiKeyQuery : IGetApiKeyQuery
    {
        private readonly IDictionary<string, ApiKey> _apiKeys;
        string apiKeyDefaultSection= "apiKeys";

        public InMemoryGetApiKeyQuery(List<ApiKey> existingApiKeys)
        {
            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

            public InMemoryGetApiKeyQuery(IConfiguration _config)
        {
            var existingApiKeys = _config.GetSection(apiKeyDefaultSection).Get<ApiKey[]>();


            //    var existingApiKeys = new List<ApiKey>
            //{
            //    new ApiKey(1, "Finance", "C5BFF7F0-B4DF-475E-A331-F737424F013C", new DateTime(2019, 01, 01),
            //        new List<string>
            //        {
            //            Roles.Employee,
            //        }),
            //    new ApiKey(2, "Reception", "5908D47C-85D3-4024-8C2B-6EC9464398AD", new DateTime(2019, 01, 01),
            //        new List<string>
            //        {
            //            Roles.Employee
            //        }),
            //    new ApiKey(3, "Management", "06795D9D-A770-44B9-9B27-03C6ABDB1BAE", new DateTime(2019, 01, 01),
            //        new List<string>
            //        {
            //            Roles.Employee,
            //            Roles.Manager
            //        }),
            //    new ApiKey(4, "Some Third Party", "FA872702-6396-45DC-89F0-FC1BE900591B", new DateTime(2019, 06, 01),
            //        new List<string>
            //        {
            //            Roles.ThirdParty
            //        })
            //};

            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}
