using ReHub.Domain.Enums;

namespace ReHub.Domain;

// TODO Move all database related stuff to the persistence layer

//[Table("users")]
//[Index("Email", IsUnique = true)]
//[Index("Id", IsUnique = true)]
public class User : BaseReHubModel
{
    public User()
    {
        Deleted = false;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Gender = GenderType.None;
        IsVerified = false;
    }

    // TODO Remove it and just use email
    public string UserName { get; set; }

    //[Required]
    //[MaxLength(120)]
    //[EncryptColumn]
    public string Email { get; set; }

    //[MaxLength(60)]
    public string? Name { get; set; }

    //[MaxLength(60)]
    public string? Surname { get; set; }

    public GenderType? Gender { get; set; }

    //[MaxLength(150)]
    public string? Image { get; set; }

    /// <summary>
    /// The name shown in a conference room
    /// </summary>
    //[Required]
    //[MaxLength(150)]
    public string DisplayName { get; set; }
    public string? Bio { get; set; }



    //[EncryptColumn]
    public string? Password { get; set; }

    /// <summary>
    /// The IdP used to register the user. In this case password will be null
    /// </summary>
    //[MaxLength(15)]
    //[Required]
    public AuthProviders AuthProvider { get; set; }

    //[Required]
    public UserType Type { get; set; }

    //[Required]
    public bool Deleted { get; set; } = false;

    //[Required]
    public bool IsVerified { get; set; } = false;

    public ICollection<ActivityAttendee> Activities { get; set; }
    public ICollection<Photo> Photos { get; set; }
    public ICollection<UserFollowing> Followings { get; set; }
    public ICollection<UserFollowing> Followers { get; set; }

    public virtual ICollection<ConferenceHistory> ConferenceActions { get; set; }

    public virtual ICollection<Notification> NotificationsForUser { get; set; }

    public virtual ICollection<Notification> NotificationsFromUser { get; set; }

    public override string ToString()
    {
        return $"User(id={Id}, name={Name}, type={Type})";
    }
}