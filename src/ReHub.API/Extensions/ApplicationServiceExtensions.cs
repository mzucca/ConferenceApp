using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReHub.Application.Core;
using ReHub.Application.Interfaces;
using ReHub.Application.Activities;
using Infrastructure.Security;
using ReHub.Infrastructure.Photos;
using ReHub.Persistence;
using ReHub.Infrastructure.Security;
using System.Text.Json.Serialization;
using System.Text.Json;
using ReHub.Utilities.Encryption;
using ReHub.DbDataModel.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using ReHub.Application.Extensions;
using ReHub.Utilities.Extensions;

namespace ReHub.BackendAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReHub Backend API", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ReHub.API.xml"));

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "ReHub Application",
                    Description = "ReHub Backend API",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lowercase
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, Array.Empty<string>()}
            });
            });

            services.ConfigureJwtServices(config);

            // Add services to the container.
            var dbConfiguration = config.GetDbConfiguration();
            if (dbConfiguration == null || string.IsNullOrEmpty(dbConfiguration.ConnectionString)) throw new ApplicationException("Invalid DB configuration");

            services.AddSingleton<IEncryptionProvider>(provider => new GenerateEncryptionProvider(dbConfiguration.EncryptionKey, dbConfiguration.EncryptionAlgorithm));


            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(dbConfiguration.ConnectionString);
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins("https://localhost:3000");
                });
            });
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                });

            services.ConfigureLocalization();

            services.AddScoped<IExternalTokenValidator,ExternalTokenValidator>();

            // TODO change with Mediators
            services.RegisterRepositories();
            services.RegisterUtilities();

            // Register all handlers 
            services.AddMediatR( cfg => cfg.RegisterServicesFromAssemblies(typeof(List.Handler).Assembly));


            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<Create>();
            services.AddHttpContextAccessor();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));
            services.AddSignalR();

            return services;
        }
    }

}
