using Microsoft.Extensions.DependencyInjection;
using ReHub.DbDataModel.Models;
using ReHub.DbDataModel.Services;

namespace ReHub.DbDataModel.Extensions
{
    public static class RegisterServices
    {
        /// <summary>
        /// Add the repositories to service for IoC
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<IUserRepository<Doctor>, DoctorRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            return services;
        }
    }
}
