using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NSwag;
using NSwag.Generation.Processors.Security;
using Trollo.API.Controllers.V1;

namespace Trollo.API.Extensions
{
    public static class SwaggerExtension
    {
        private static readonly Type[] Controllers = new[]
        {
            typeof(AuthController),
            typeof(HomeController),
            typeof(BoardController)
        }.OrderBy(c => c.Name).ToArray();

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddOpenApiDocument(settings =>
            {
                settings.Title = "TrolloAPI";
                settings.Description = "API Documentation for Trollo";
                settings.DocumentName = "TrolloAPI";
                settings.SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters =
                        {new StringEnumConverter(new CamelCaseNamingStrategy()), new IsoDateTimeConverter()}
                };
                settings.AddOperationFilter(context => Controllers.Any(c => c == context.ControllerType));
                settings.AddSecurity(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT Token}"
                });

                settings.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor(JwtBearerDefaults.AuthenticationScheme));
            });
        }

        public static void UseSwagger(this IApplicationBuilder app)
        {
            app.UseOpenApi(settings =>
            {
                settings.Path = "/api/v1/docs/swagger.json";
                settings.DocumentName = "TrolloAPI";
            });
            app.UseSwaggerUi3(settings =>
            {
                settings.DocExpansion = "list";
                settings.EnableTryItOut = true;
                settings.Path = "/api/v1/docs";
                settings.DocumentPath = "/api/v1/docs/swagger.json";
            });
        }
    }
}