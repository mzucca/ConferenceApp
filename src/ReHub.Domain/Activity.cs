using ReHub.Domain.Enums;

namespace ReHub.Domain
{
    /// <summary>
    /// Describe each user activity recorded or prescripted for a user
    /// </summary>
    public class Activity : BaseReHubModel
    {
        // TODO add Stava information as linked table
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public bool IsCancelled { get; set; }
        public ICollection<ActivityAttendee> Attendees { get; set; } = new List<ActivityAttendee>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
