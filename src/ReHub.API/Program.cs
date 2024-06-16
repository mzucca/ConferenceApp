using Serilog;
using ReHub.BackendAPI.Extensions;
using ReHub.BackendAPI.Middleware;

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

            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddCoreAdmin();

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

            //Add support to logging request with SERILOG
            app.UseSerilogRequestLogging();

            app.UseCoreAdminCustomTitle("ReHub App Admin Tool");

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
