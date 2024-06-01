using ReHub.Utilities.Extensions;
using System.IdentityModel.Tokens.Jwt;

namespace Rehub.Utilities.Models
{
    public class GoogleClaims
    {
        private GoogleClaims() { }
        public static GoogleClaims FromToken(string token)
        {
            var claims = new GoogleClaims();
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            claims.Iss = jwtSecurityToken.GetValue("iss", string.Empty);
            claims.Azp = jwtSecurityToken.GetValue("azp", string.Empty);
            claims.Email = jwtSecurityToken.GetValue("email", string.Empty);
            claims.EmailVerified = jwtSecurityToken.GetValue("email_verified", false);
            claims.PictureUrl = jwtSecurityToken.GetValue("picture", string.Empty);
            claims.FirstName = jwtSecurityToken.GetValue("given_name", string.Empty);
            claims.LastName = jwtSecurityToken.GetValue("family_name", string.Empty);
            claims.SignatureAlgorithm = jwtSecurityToken.SignatureAlgorithm;
            claims.ValidFrom = jwtSecurityToken.ValidFrom;
            claims.ValidTo = jwtSecurityToken.ValidTo;


            return claims;
        }
        public string Iss { get; set; }
        public string Azp { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SignatureAlgorithm { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; private set; }
    }

}
