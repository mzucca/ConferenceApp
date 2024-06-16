namespace ReHub.Domain;

public class Comment : BaseReHubModel
{
    public string Body { get; set; }
    public User Author { get; set; }
    public Activity Activity { get; set; }

}