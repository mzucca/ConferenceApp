using ReHub.Db.PostgreSQL;
using ReHub.DbDataModel.Models;

namespace ReHub.DbDataModel.Extensions
{
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

            return users.FirstOrDefault<T>(u => u.Email == email);
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
            var users = dataContext.Set<T>();
            if (users == null) return null;

            return users.FirstOrDefault<T>(u => u.Id == id);

        }
    }
}
