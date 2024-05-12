
using Microsoft.EntityFrameworkCore;
using ReHub.Db.PostgreSQL;
using ReHub.DbDataModel;
using Serilog;
using ReHub.DbDataModel.Extensions;

namespace BackendAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add support to logging with SERILOG
            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            builder.Configuration.AddEnvironmentVariables(prefix: "ReHub");
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddDbContext<PostgresDbContext>();

            builder.Services.AddScoped<DataContext, PostgresDbContext>();
            builder.Services.RegisterRepositories();
            var app = builder.Build();
            MigrateDatabase(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            //Add support to logging request with SERILOG
            app.UseSerilogRequestLogging();

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
                using (var appContext = scope.ServiceProvider.GetRequiredService<DataContext>())
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
