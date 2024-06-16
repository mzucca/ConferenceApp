namespace ReHub.Application.Users;

public class UserDefinition
{
    public int Id { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string? Image { get; set; }
}
