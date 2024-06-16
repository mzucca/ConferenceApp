
namespace ReHub.Domain;

//[Table("payments")]
public partial class Payment : BaseReHubModel
{
    //[Key]
    //[Column("id")]
    public int Id { get; set; }

    //[Column("amount")]
    public double Amount { get; set; }

    //[Column("lesson_package_id")]
    public int LessonPackageId { get; set; }

    //[Column("coupon_id")]
    public int? CouponId { get; set; }

    //[Column("client_id")]
    public int ClientId { get; set; }

    //[ForeignKey("ClientId")]
    //[InverseProperty("Payments")]
    public virtual Client Client { get; set; } = null!;

    //[ForeignKey("CouponId")]
    //[InverseProperty("Payments")]
    public virtual DiscountCoupon? Coupon { get; set; }

    //[ForeignKey("LessonPackageId")]
    //[InverseProperty("Payments")]
    public virtual LessonPackage LessonPackage { get; set; } = null!;
    public override string ToString()
    {
        return $"Payment(id={Id}, amount={Amount})";
    }
}
