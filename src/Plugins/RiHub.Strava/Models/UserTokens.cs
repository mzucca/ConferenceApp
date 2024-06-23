namespace RiHub.Strava.Models
{
    public class UserTokens
    {
        // The volatile access token
        public string AccessToken {  get; set; }
        // The persistent refresh token to generate new tokens
        public string RefreshToken {  get; set; }
    }
}
