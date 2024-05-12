using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ReHub.Utilities.Encryption;

namespace ReHub.DbDataModel.Models;

[Table("users")]
[Index("Email", IsUnique = true)]
[Index("Id", IsUnique = true)]
public abstract class User
{
    public User()
    {
        Deleted = false;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Gender = GenderType.None;
        IsVerified = false;
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    [EncryptColumn]
    public string Email { get; set; }

    [Required]
    [MaxLength(60)]
    public string Name { get; set; }

    [Required]
    [MaxLength(60)]
    public string Surname { get; set; }

    [Required]
    public GenderType Gender { get; set; }

    [MaxLength(150)]
    public string? AvatarUrl { get; set; }

    [Required]
    [EncryptColumn]
    public string Password { get; set; }

    [Required]
    public UserType Type { get; set; }

    public bool Deleted { get; set; } = false;

    public bool IsVerified { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public virtual ICollection<ConferenceHistory> ConferenceActions { get; set; }

    public virtual ICollection<Notification> NotificationsForUser { get; set; }

    public virtual ICollection<Notification> NotificationsFromUser { get; set; }

    public override string ToString()
    {
        return $"User(id={Id}, name={Name}, type={Type})";
    }
}