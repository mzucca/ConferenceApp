using ReHub.Domain.Enums;

namespace ReHub.Domain;

//[Table("appointments")]
public partial class Appointment : BaseReHubModel
{
    //[Column("date")]
    public DateOnly Date { get; set; }

    //[Column("time")]
    public TimeSpan Time { get; set; }

    //[Column("status")]
    public AppointmentStatusType Status { get; set; } = AppointmentStatusType.Pending;

    //[Column("max_listeners")]
    public int MaxListeners { get; set; }

    //[Column("speaker_id")]
    public int? SpeakerId { get; set; }

    //[InverseProperty("Appointment")]
    public virtual ICollection<AppointmentClient> AppointmentClients { get; set; } = new List<AppointmentClient>();

    //[ForeignKey("SpeakerId")]
    //[InverseProperty("Appointments")]
    // TODO chane speaker to Doctor 
    public virtual User Speaker { get; set; }
    public override string ToString()
    {
        return $"Appointment(id={Id})";
    }
}
