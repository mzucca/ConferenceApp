using ReHub.Domain.Enums;

namespace ReHub.Domain;

// TODO rename client to customer
//[Table("clients")]
public class Client : User
{
    //[ForeignKey("User")]
    //public override int Id { get; set; }
    public Client() : base()
    {
        Balance = 0;
    }

    //[Required]
    public UserSubType SubType { get; set; } = UserSubType.Anamnesis; // NON Capisco forse è lo stato ???

    //[Required]
    public int Balance { get; set; } = 0;

    public virtual ClientDetails ClientDetails { get; set; }

    public int? DoctorId { get; set; }

    //[ForeignKey("DoctorId")]
    public virtual User Doctor { get; set; }
    public int? ReferrerId { get; set; }

    //[ForeignKey("ReferrerId")]
    public virtual ReferrerDoctor Referrer { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; }

    public virtual ICollection<Payment> Payments { get; set; }

    public virtual ICollection<DiscountCoupon> UsedCoupons { get; set; }


    public override string ToString()
    {
        return $"Client(id={Id}, name={Name})";
    }
}