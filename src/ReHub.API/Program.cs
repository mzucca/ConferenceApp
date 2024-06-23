using Serilog;
using ReHub.BackendAPI.Extensions;
using ReHub.BackendAPI.Middleware;
using Microsoft.AspNetCore.Diagnostics;
using RiHub.Strava;

namespace ReHub.BackendAPI
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


            // Add plugins
            builder.Services.AddCoreAdmin();
            builder.Services.AddStravaPlugin(builder.Configuration);

            builder.Services.AddApplicationServices(builder.Configuration);

            var app = builder.Build();
            //MigrateDatabase(app);
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseRouting();

            // Configure the HTTP request pipeline.
            app.UseMiddleware<ExceptionMiddleware>();

            // https://docs.nwebsec.com/en/latest/ check for newer options
            //app.UseXContentTypeOptions();
            //app.UseReferrerPolicy(opt => opt.NoReferrer());
            //app.UseXXssProtection(opt => opt.EnabledWithBlockMode());
            //app.UseXfo(opt => opt.Deny());
            //app.UseCsp(opt => opt
            //    .BlockAllMixedContent()
            //    .StyleSources(s => s.Self().CustomSources("https://fonts.googleapis.com"))
            //    .FontSources(s => s.Self().CustomSources("https://fonts.gstatic.com", "data:"))
            //    .FormActions(s => s.Self())
            //    .FrameAncestors(s => s.Self())
            //    .ImageSources(s => s.Self().CustomSources("blob:", "https://res.cloudinary.com", "https://platform-lookaside.fbsbx.com"))
            //    .ScriptSources(s => s.Self())
            //);

            app.ConfigureLocalization();

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
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context => 
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    var logger = context.Features.Get<ILogger<Program>>();
                    Type type = exception?.Error.GetType();
                    if(type==null)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Uncaught error");
                    }
                    else
                    {
                        logger?.LogError(exception.Error?.Message);
                        switch (type)
                        {
                            case Type _ when type == typeof(InvalidTimeZoneException):
                                context.Response.StatusCode = 422;
                                await context.Response.WriteAsync(exception.Error?.Message);
                                break;
                            default:
                                context.Response.StatusCode = 500;
                                await context.Response.WriteAsync(exception.Error?.Message);
                                break;
                        }
                    }

                });
            });

            //Add support to logging request with SERILOG
            app.UseSerilogRequestLogging();

            // Plugins
            app.UseCoreAdminCustomTitle("ReHub App Admin Tool");
            app.UseStravaPlugin("plugins");

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
        //private static void MigrateDatabase(WebApplication app)
        //{
        //    using (var scope = app.Services.CreateScope())
        //    {
        //        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        //        if (logger == null)
        //        {
        //            Console.WriteLine("Error creating the logger. Cannot Migrate DB");
        //            throw new Exception("Error creating the logger");

        //        }
        //        using (var appContext = scope.ServiceProvider.GetRequiredService<PostgresDbContext>())
        //        {
        //            try
        //            {
        //                appContext.Database.Migrate();
        //            }
        //            catch (Exception ex)
        //            {
        //                logger.LogError($"Error migrating the database: {ex.Message}");
        //                throw ex;
        //            }
        //        }
        //    }
        //}
    }
}
