using Microsoft.EntityFrameworkCore;
using ReHub.Db.PostgreSQL;
using ReHub.Utilities.Extensions;
using Serilog;
using ReHub.DbDataModel.Extensions;
using Rehub.Authorization.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Rehub.BackendAPI
{
    public class Program
    {
        internal static readonly string CORS_ALLOW_LOCALHOST = "AllowLocalhost";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // TODO manage CORS policies
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(CORS_ALLOW_LOCALHOST,
                builder =>
                {
                    builder
                    .WithOrigins("http://localhost:9000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });

            //Add support to logging with SERILOG
            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            builder.Configuration.AddEnvironmentVariables(prefix: "ReHub");
            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReHub Backend API", Version = "v1" });

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

            builder.Services.ConfigureJwtServices(builder.Configuration);

            //builder.Services.AddScoped<DataContext, PostgresDbContext>();
            builder.Services.AddDbContext<PostgresDbContext>();
            builder.Services.RegisterRepositories();
            builder.Services.RegisterUtilities();

            builder.Services.AddCoreAdmin();

            var app = builder.Build();
            MigrateDatabase(app);
            app.UseStaticFiles();
            app.UseCors(CORS_ALLOW_LOCALHOST);
            app.UseRouting();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(); // c =>
                //{
                //    c.SwaggerEndpoint("./swagger/v1/swagger.json", "ReHub Backend API V1");
                //    c.DocumentTitle = "ReHub Backend API";
                //    c.RoutePrefix = string.Empty;
                //});
            }

            app.UseAuthentication();
            app.UseAuthorization();

            //Add support to logging request with SERILOG
            app.UseSerilogRequestLogging();

            app.UseCoreAdminCustomTitle("Core Admin ReHub App");

            // Required for Core Admin
            app.MapDefaultControllerRoute();


            app.MapControllers();
            app.Logger.LogInformation("Starting ReHub backend server");
            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                app.Logger.LogCritical($"Cannot start app:{ex.Message}");
            }

        }
        private static void MigrateDatabase(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                if(logger == null)
                {
                    Console.WriteLine("Error creating the logger. Cannot Migrate DB");
                    throw new Exception("Error creating the logger");

                }
                using (var appContext = scope.ServiceProvider.GetRequiredService<PostgresDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError($"Error migrating the database: {ex.Message}");
                        throw ex;
                    }
                }
            }
        }
    }
}
