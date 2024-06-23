//using Microsoft.Extensions.DependencyInjection;
//using ReHub.DbDataModel.Services;
//using ReHub.Domain;

using ReHub.Application.Services;
using ReHub.Application.Users;
using ReHub.DbDataModel.Services;
using ReHub.Domain;

namespace ReHub.DbDataModel.Extensions;

public static class RegisterServices
{
    /// <summary>
    /// Add the repositories to service for IoC
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        // TODO add mediatr pattern
        services.AddScoped<IUserRepository<Client>, UserRepository<Client>>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IUserRepository<User>, UserRepository<User>>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
