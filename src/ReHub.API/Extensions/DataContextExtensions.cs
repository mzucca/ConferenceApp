using ReHub.Domain;
using ReHub.Persistence;

namespace ReHub.BackendAPI.Extensions;

public static class DataContextExtensions
{
    /// <summary>
    ///  Get a User (client, doctor or admin) from email
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataContext"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public static T? GetUserByEmail<T>(this DataContext dataContext, string email) where T : User
    {
        var users = dataContext.Set<T>();
        if (users == null) return null;
        email = email.Trim().ToLowerInvariant();
        return users.FirstOrDefault(u => u.Email == email);
    }
    /// <summary>
    ///  Get a User (client, doctor or admin) from Id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataContext"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static T? GetById<T>(this DataContext dataContext, int id) where T : BaseReHubModel
    {
        var entities = dataContext.Set<T>();
        if (entities == null) return null;

        return entities.FirstOrDefault(u => u.Id == id);

    }
}
