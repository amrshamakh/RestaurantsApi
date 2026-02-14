using Microsoft.OpenApi.Models;
using Restaurants.API.middlewares;
using Serilog;

namespace Restaurants.API.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void Addpresentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearerAuth"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddScoped<ErrorHandlingMiddle>();

            builder.Host.UseSerilog((context, configuration) =>
            configuration
            .ReadFrom.Configuration(context.Configuration)
            );
        }
    }
}
