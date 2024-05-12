using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReHub.DbDataModel.Models;

[Table("referrer_doctors")]
[Index("Name", IsUnique = true)]
[Index("ReferralCode", IsUnique = true)]
public partial class ReferrerDoctor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("referral_code")]
    public string ReferralCode { get; set; } = null!;

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    //[InverseProperty("Referrer")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
    public override string ToString()
    {
        return $"ReferrerDoctor(Id={Id}, Name={Name})";
    }
}
