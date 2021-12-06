using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Wepgcomp.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        const string Title = "Store Library";
        const string Description = "A Store Library Rest API Example.";
        const string Version = "v1";

        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var xmlComments = Path.Combine(AppContext.BaseDirectory, "Store.Library.xml");

                options.SwaggerDoc(Version, new OpenApiInfo
                {
                    Title = Title,
                    Description = Description,
                    Version = Version
                });

                options.AddSecurityDefinition("api-key", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "x-api-key",
                    In = ParameterLocation.Header
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "api-key",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new[] { "readAccess", "writeAccess" }
                    }
                });

                options.IncludeXmlComments(xmlComments);
            });
        }

        public static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "docs/swagger/{documentname}/swagger.json";
            });

            app.UseReDoc(options =>
            {
                options.DocumentTitle = Title;
                options.RoutePrefix = "docs";
                options.SpecUrl($"swagger/{Version}/swagger.json");
            });
        }
    }
}
