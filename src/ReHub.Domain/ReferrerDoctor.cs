
namespace ReHub.Domain;

//[Table("referrer_doctors")]
//[Index("Name", IsUnique = true)]
//[Index("ReferralCode", IsUnique = true)]
public partial class ReferrerDoctor : BaseReHubModel
{

    //[Column("name")]
    public string Name { get; set; } = null!;

    //[Column("referral_code")]
    public string ReferralCode { get; set; } = null!;

    //[Column("comment")]
    public string? Comment { get; set; }

    //[InverseProperty("Referrer")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
    public override string ToString()
    {
        return $"ReferrerDoctor(Id={Id}, Name={Name})";
    }
}
