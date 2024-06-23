namespace ReHub.Application.Users;

public class UserDto
{
    // TODO check the difference with getMe request
    /// <summary>
    /// How to represents this user in conference or communications.
    /// </summary>
    public string DisplayName { get; set; }
    /// <summary>
    /// The identification token
    /// </summary>
    public string Token { get; set; }
    /// <summary>
    /// The url to avatar
    /// </summary>
    public string? Image { get; set; }
    /// <summary>
    /// The user email used to identify the user.
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// The role for this user
    /// </summary>
    public string Role { get; set; }

}
