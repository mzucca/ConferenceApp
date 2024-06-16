using System.ComponentModel.DataAnnotations;

namespace ReHub.Application.Users;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string Password { get; set; }

    [Required]
    public string DisplayName { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string AuthProvider { get; set; }
    public string Image { get; set; }

}
