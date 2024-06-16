namespace ReHub.Domain;

public class ActivityAttendee : BaseReHubModel
{
    public int UserId { get; set; }
    public User AppUser { get; set; }
    public int ActivityId { get; set; }
    public Activity Activity { get; set; }
    public bool IsHost { get; set; }

}