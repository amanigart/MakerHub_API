using API_JTCN.Identity;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API_JTCN.Extensions
{
    public static class ServiceExtensions
    {
        // Configuration Cors policies
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // Configuration des Auth policies
        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("authPolicy", policy => policy.RequireAuthenticatedUser());
            });
        }

        // Configuration de l'injection de dépendance du LoggerService
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        // Configuration de l'injection de dépendance du Repository Manager
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        // Configuration de l'injection de dépendance du Service Manager
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        // Configuration de l'injection de dépendance du Service Authentication
        public static void ConfigureTokenService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }

        // Configuration JWT tokens
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration config)
        {
            var jwtSettings = config.GetSection("JwtSettings");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["secret"])),
                            ValidateIssuer = true,
                            ValidIssuer = jwtSettings["issuer"],
                            ValidateLifetime = true,
                            ValidateAudience = true,
                            ValidAudience = jwtSettings["audience"]
                        };
                    });
        }


        //Configure Swagger pour documentation
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "swagger.xml");
                c.IncludeXmlComments(filePath);
                c.DescribeAllParametersInCamelCase();
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "JTCN API",
                    Description = "Gestion du club JTCN",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "ad.manigart@gmail.com",
                        Name = "Adrien Manigart"
                    }
                });
            });
        }
    }
}
