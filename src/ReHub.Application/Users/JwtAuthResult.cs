using System.Text.Json.Serialization;

namespace ReHub.Application.Users;

public class JwtAuthResult
{
    [JsonPropertyName("accessToken")] public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("refreshToken")] public RefreshToken RefreshToken { get; set; } = new();
}