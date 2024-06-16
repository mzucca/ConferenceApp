namespace ReHub.Application.Users;

public class UserDto
{
    // TODO check the difference with getMe request
    public string DisplayName { get; set; }
    public string Token { get; set; }
    public string? Image { get; set; }
    public string Email { get; set; }

}
