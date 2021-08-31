using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Bread.API.Configurations
{
    internal static class SwaggerExtensions
    {
        internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Bread API",
                    Version = "v1",
                    Description = "Stephen's Demo .NET Core REST API CQRS implementation with EF Core, Repository model and DDD using Clean Architecture.",
                });

                var securitySchema = new OpenApiSecurityScheme {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                options.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement {
                    { securitySchema, new[] { "Bearer" } }
                };
                options.AddSecurityRequirement(securityRequirement);

                //var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                //var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                //options.IncludeXmlComments(commentsFile);
            });

            return services;
        }

        internal static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stephen's Demo .NET Core REST API V2");
            });

            return app;
        }
    }
}
