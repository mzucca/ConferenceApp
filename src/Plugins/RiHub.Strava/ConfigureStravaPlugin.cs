using Microsoft.AspNetCore.Mvc.ApplicationParts;
using RiHub.Strava.Authentication;
using RiHub.Strava.Controllers;

namespace RiHub.Strava
{
    public static class ConfigureStravaPluginServices
    {
        public static void AddStravaPlugin(this IServiceCollection services, IConfiguration confguration)
        {
            var assembly = typeof(StravaApiController).Assembly;
            // This creates an AssemblyPart, but does not create any related parts for items such as views.
            var part = new AssemblyPart(assembly);
            services.AddControllersWithViews()
                .ConfigureApplicationPartManager(apm => apm.ApplicationParts.Add(part));

//            services.AddControllers().AddApplicationPart(assembly);
            services.AddEndpointsApiExplorer();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.AddSingleton<IAuthenticatorHolder, AuthenticatorHolder>();
            var stravaConfigSection = confguration.GetSection(StravaConfig.CONFIG);
            if (stravaConfigSection == null) throw new ApplicationException($"Can't find strava configuration. Have you add {StravaConfig.CONFIG} section in your appsettings?");
            var configOptions = new StravaConfig();
            stravaConfigSection.Bind(configOptions);

            services.AddSingleton<StravaConfig>(configOptions);

        }
        public static void UseStravaPlugin(this IApplicationBuilder app, string customUrlPrefix)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "strava",
                    pattern: customUrlPrefix + "/{controller=StravaApi}/{action=GetActivities}");

            });
        }
    }
}
