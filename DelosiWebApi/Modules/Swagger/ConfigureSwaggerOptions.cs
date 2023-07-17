using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DelosiWebApi.Modules.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;


        public void Configure(SwaggerGenOptions options)
        {
            
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "Delosi Microservicios",
                Description = "Microservicios IT Delosi ",
                TermsOfService = new Uri("https://google.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "William Reynaga",
                    Email = "iwilliamxf@gmail.com",
                    Url = new Uri("https://google.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Use under LICX",
                    Url = new Uri("https://google.com/licence")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "Esta versión de la API se encuentra deprecada.";
            }

            return info;
        }
    }
}
