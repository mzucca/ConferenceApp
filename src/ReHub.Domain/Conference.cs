namespace ReHub.Domain;

//[Table("conference")]
//[Index("Id", IsUnique = true)]
public partial class Conference : BaseReHubModel
{
    //[Column("channel_name")]
    public string ChannelName { get; set; } = null!;

    //[Column("is_active")]
    public bool IsActive { get; set; }

    //[Column("channel_admin_id")]
    public int? ChannelAdminId { get; set; }

    //[ForeignKey("ChannelAdminId")]
    //[InverseProperty("Conferences")]
    public virtual User? ChannelAdmin { get; set; }

    //[InverseProperty("Conference")]
    public virtual ICollection<ConferenceHistory> ConferenceHistories { get; set; } = new List<ConferenceHistory>();
    public override string ToString()
    {
        return $"Conference(id={Id}, channel_name={ChannelName})";
    }
}
