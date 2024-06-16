namespace ReHub.Domain;

//[Table("conference_history")]
//[Index("Id", IsUnique = true)]
public partial class ConferenceHistory : BaseReHubModel
{
    //[Column("action")]
    public string Action { get; set; } = null!;

    //[Column("conference_id")]
    public int? ConferenceId { get; set; }

    //[Column("actor_id")]
    public int? ActorId { get; set; }

    //[ForeignKey("ActorId")]
    //[InverseProperty("ConferenceHistories")]
    public virtual User? Actor { get; set; }

    //[ForeignKey("ConferenceId")]
    //[InverseProperty("ConferenceHistories")]
    public virtual Conference? Conference { get; set; }
    public override string ToString()
    {
        return $"ConfHistory(id={Id}, action={Action}, actor_id={ActorId})";
    }
}
