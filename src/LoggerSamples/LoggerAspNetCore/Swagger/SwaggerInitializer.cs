namespace LoggerAspNetCore.Swagger
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using System;

    /// <summary>
    /// Defines the <see cref="SwaggerInitializer" />.
    /// </summary>
    public static class SwaggerInitializer
    {
        /// <summary>
        /// The AddSwagger.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = SwaggerConfiguration.DocNameV1;

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = SwaggerConfiguration.DocInfoTitle,
                    Version = groupName,
                    Description = SwaggerConfiguration.DocInfoDescription,
                    Contact = new OpenApiContact
                    {
                        Name = SwaggerConfiguration.ContactName,
                        Email = string.Empty,
                        Url = new Uri(SwaggerConfiguration.ContactUrl),
                    }
                });

                options.AddSecurityDefinition(ApiKeyConstants.HeaderName, new OpenApiSecurityScheme
                {
                    Description = "Api key needed to access the endpoints. X-Api-Key: My_API_Key",
                    In = ParameterLocation.Header,
                    Name = ApiKeyConstants.HeaderName,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = ApiKeyConstants.HeaderName,
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = ApiKeyConstants.HeaderName },
                        },
                        new string[] {}
                    }
                });
            });



            services.AddSwaggerGenNewtonsoftSupport();
        }

        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/>.</param>
        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });
        }
    }
}
