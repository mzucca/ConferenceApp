using Microsoft.Extensions.DependencyInjection;
using ReHub.Utilities.Services;

namespace ReHub.Utilities.Extensions
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterUtilities(this IServiceCollection services)
        {
            services.AddScoped<IBackgroundTaskQueue, MailSender>();
            return services;
        }
    }
}