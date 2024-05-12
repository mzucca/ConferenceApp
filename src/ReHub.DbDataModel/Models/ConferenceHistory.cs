using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReHub.DbDataModel.Models;

[Table("conference_history")]
[Index("Id", IsUnique = true)]
public partial class ConferenceHistory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("action")]
    public string Action { get; set; } = null!;

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("conference_id")]
    public int? ConferenceId { get; set; }

    [Column("actor_id")]
    public int? ActorId { get; set; }

    [ForeignKey("ActorId")]
    //[InverseProperty("ConferenceHistories")]
    public virtual User? Actor { get; set; }

    [ForeignKey("ConferenceId")]
    //[InverseProperty("ConferenceHistories")]
    public virtual Conference? Conference { get; set; }
    public override string ToString()
    {
        return $"ConfHistory(id={Id}, action={Action}, actor_id={ActorId})";
    }
}
