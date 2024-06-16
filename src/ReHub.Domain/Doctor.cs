using ReHub.Domain.Enums;

namespace ReHub.Domain;

//[Table("doctors")]
public class Doctor : User
{
    public Doctor() : base()
    {
        Type = UserType.Doctor;
    }

    //[Required]
    public UserSubType SubType { get; set; }

    //[MaxLength(500)]
    public string About { get; set; }

    public virtual ICollection<Client> Clients { get; set; }

    public virtual ICollection<Conference> AdministratedChannels { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; }

    public override string ToString()
    {
        return $"Doctor(id={Id}, name={Name}, subtype={SubType})";
    }
}