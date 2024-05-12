using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReHub.DbDataModel.Models;

[Table("notification_recipients")]
[Index("NotificationId")]
[Index("UserId")]
public partial class NotificationRecipient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("notification_id")]
    public int NotificationId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("user_seen")]
    public bool? UserSeen { get; set; }

    [ForeignKey("NotificationId")]
    //[InverseProperty("NotificationRecipients")]
    public virtual Notification Notification { get; set; } = null!;

    [ForeignKey("UserId")]
    //[InverseProperty("NotificationRecipients")]
    public virtual User User { get; set; } = null!;
    public override string ToString()
    {
        return $"N_Recipient(notification_id={NotificationId}, user_id={UserId}, seen={UserSeen})";
    }
}
