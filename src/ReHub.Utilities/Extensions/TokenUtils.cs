using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ReHub.Utilities.Extensions
{
    public static class TokenUtils
    {
        public static string GetValue(this JwtSecurityToken token, string claimType, string defaultValue = "")
        {
            var value = token.Claims.FirstOrDefault(claim => claim.Type == claimType);
            if (value == null) { return defaultValue; }
            return value.Value;
        }
        public static bool GetValue(this JwtSecurityToken token, string claimType, bool defaultValue = false)
        {
            var value = token.Claims.FirstOrDefault(claim => claim.Type == claimType);
            if (value == null) { return defaultValue; }

            bool result = defaultValue;
            if (bool.TryParse(value.Value, out result))
                return result;
            else
                return defaultValue;
        }
        public static string CreateLiveKitToken(string user, string room)
        {
            var apiSecret = "vjcyCv8Hk1quPuTJz9nFd8EGtRnHIfilUYOqSvKIlDN";
            var apiKey = "API277GVY4g2ZE2";
            var now = DateTime.UtcNow;

            JwtHeader headers = new(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(apiSecret)), "HS256"));
            JwtPayload payload = [];

            long unixTimestamp = now.ToUnixTimestamp();
            long unixExpiration = now.AddHours(4).ToUnixTimestamp();

            payload.Add("exp", unixExpiration);
            payload.Add("name", user);
            payload.Add("iss", apiKey); // not the apiSecret
            payload.Add("nbf", unixTimestamp); // the time created
            payload.Add("sub", user);

            var videoGrants = new Dictionary<string, object>()
            {
                //{ "canPublish", true },
                //{ "canPublishData", true },
                //{ "canSubscribe", true },
                { "room", room },
                { "roomJoin", true },
            };

            payload.Add("video", videoGrants);

            JwtSecurityToken token = new(headers, payload);
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }

}
