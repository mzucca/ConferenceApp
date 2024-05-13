using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ReHub.DbDataModel.Models;

namespace Rehub.Authorization.Extensions
{
    public static class AuthorizationExtensions
    {
        public static UserType GetRole(this ClaimsPrincipal user)
        {
            Object result;
            if (user == null) return UserType.None;
            var role = user.FindFirstValue(ClaimTypes.Role);

            if (Enum.TryParse(typeof(UserType), role, out result))
                return (UserType) result;
            else 
                return UserType.None;
        }
        public static int GetUserId(this ClaimsPrincipal user)
        {
            Object result;
            if (user == null) return -1;
            IdentityOptions options = new();

            var role = user.FindFirstValue(options.ClaimsIdentity.UserIdClaimType);
            if(string.IsNullOrEmpty(role)) return -1;

            return Convert.ToInt32(role);

        }
    }
}
