using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ReHub.Domain.Enums;

namespace Rehub.Authorization.Extensions
{
    public static class AuthorizationExtensions
    {
        public static UserRole GetRole(this ClaimsPrincipal user)
        {
            Object result;
            if (user == null) return UserRole.None;
            var role = user.FindFirstValue(ClaimTypes.Role);

            if (Enum.TryParse(typeof(UserRole), role, out result))
                return (UserRole) result;
            else 
                return UserRole.None;
        }
        public static int GetUserId(this ClaimsPrincipal user)
        {
            if (user == null) return -1;
            IdentityOptions options = new();

            var role = user.FindFirstValue(options.ClaimsIdentity.UserIdClaimType);
            if(string.IsNullOrEmpty(role)) return -1;

            return Convert.ToInt32(role);

        }
    }
}
