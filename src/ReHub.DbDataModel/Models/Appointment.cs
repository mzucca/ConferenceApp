using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReHub.DbDataModel.Models;

[Table("appointments")]
public partial class Appointment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("time")]
    public TimeSpan Time { get; set; }

    [Column("status")]
    public string Status { get; set; } = null!;

    [Column("max_listeners")]
    public int MaxListeners { get; set; }

    [Column("speaker_id")]
    public int? SpeakerId { get; set; }

    //[InverseProperty("Appointment")]
    public virtual ICollection<AppointmentClient> AppointmentClients { get; set; } = new List<AppointmentClient>();

    //[ForeignKey("SpeakerId")]
    //[InverseProperty("Appointments")]
    // TODO chane speaker to Doctor 
    public virtual Doctor Speaker { get; set; }
    public override string ToString()
    {
        return $"Appointment(id={Id})";
    }
}
