using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReHub.DbDataModel.Models;

[Table("discount_coupons")]
[Index("Name", IsUnique = true)]
public partial class DiscountCoupon
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("coupon_type")]
    public CouponType CouponType { get; set; }

    [Column("discount_type")]
    public CouponDiscountType DiscountType { get; set; }

    [Column("discount")]
    public double Discount { get; set; }

    [Column("validity_until")]
    public DateTime ValidityUntil { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    //[InverseProperty("Coupon")]
    public virtual ICollection<CouponUser> CouponUsers { get; set; } = new List<CouponUser>();

    //[InverseProperty("Coupon")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public override string ToString()
    {
        return $"DiscountCoupon(id={Id})";
    }
}
