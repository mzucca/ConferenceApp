namespace ReHub.Domain;

//[Table("notifications")]
//[Index("SenderId")]
public partial class Notification : BaseReHubModel
{
    //[Column("message")]
    public string Message { get; set; } = null!;

    //[Column("sender_id")]
    public int SenderId { get; set; }

    //[InverseProperty("Notification")]
    public virtual ICollection<NotificationRecipient> NotificationRecipients { get; set; } = new List<NotificationRecipient>();

    //[ForeignKey("SenderId")]
    public virtual User Sender { get; set; } = null!;
    public override string ToString()
    {
        return $"Notification(id={Id}, message={Message})";
    }
}
