using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace ReHub.BackendAPI.Extensions
{
    public static class LocalizationExtensions
    {
        internal const string defaultCulture = "en";
        internal const string ResourcePath = "Resources";

        internal static CultureInfo[] supportedCultures = new[]
        {
            new CultureInfo(defaultCulture),
            new CultureInfo("it")
        };
        public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
        {
            services
                .AddLocalization(options => options.ResourcesPath = ResourcePath)
                .Configure<RequestLocalizationOptions>(options =>
                {
                    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                });

            return services;
        }
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
        }
    }

}
