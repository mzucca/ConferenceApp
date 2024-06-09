using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace API.Extensions
{
    public static class TokenExtensions
    {
        public static long ToUnixTimestamp(this DateTime date)
        {
            // Calculate the Unix timestamp using TimeSpan

            TimeSpan elapsedTime = date - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)elapsedTime.TotalSeconds; ;
        }
        public static string CreateLiveKitToken(string user, string room)
        {
            var apiSecret = "vjcyCv8Hk1quPuTJz9nFd8EGtRnHIfilUYOqSvKIlDN";
            var apiKey = "API277GVY4g2ZE2";
            var now = DateTime.UtcNow;

            JwtHeader headers = new(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(apiSecret)), "HS256"));
            JwtPayload payload = new JwtPayload();

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
