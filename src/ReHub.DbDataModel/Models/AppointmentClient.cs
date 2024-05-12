using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReHub.DbDataModel.Models;

[Table("appointment_clients")]
public partial class AppointmentClient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("client_id")]
    public int? ClientId { get; set; }

    [Column("appointment_id")]
    public int? AppointmentId { get; set; }

    [Column("pain_rate_before")]
    public int? PainRateBefore { get; set; }

    [Column("pain_rate_after")]
    public int? PainRateAfter { get; set; }

    [ForeignKey("AppointmentId")]
    //[InverseProperty("AppointmentClients")]
    public virtual Appointment? Appointment { get; set; }

    [ForeignKey("ClientId")]
    //[InverseProperty("AppointmentClients")]
    public virtual Client? Client { get; set; }
}
