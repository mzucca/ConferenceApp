using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReHub.DbDataModel.Models;

[Table("coupon_users")]
public partial class CouponUser
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("coupon_id")]
    public int CouponId { get; set; }

    [Column("client_id")]
    public int ClientId { get; set; }

    [Column("use_count")]
    public int UseCount { get; set; }

    [ForeignKey("ClientId")]
    //[InverseProperty("CouponUsers")]
    public virtual Client Client { get; set; } = null!;

    [ForeignKey("CouponId")]
    //[InverseProperty("CouponUsers")]
    public virtual DiscountCoupon Coupon { get; set; } = null!;
}
