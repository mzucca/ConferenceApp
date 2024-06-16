﻿namespace ReHub.Domain;

//[Table("coupon_users")]
public partial class CouponUser : BaseReHubModel
{
    //[Column("coupon_id")]
    public int CouponId { get; set; }

    //[Column("client_id")]
    public int ClientId { get; set; }

    //[Column("use_count")]
    public int UseCount { get; set; }

    //[ForeignKey("ClientId")]
    //[InverseProperty("CouponUsers")]
    public virtual Client Client { get; set; } = null!;

    //[ForeignKey("CouponId")]
    //[InverseProperty("CouponUsers")]
    public virtual DiscountCoupon Coupon { get; set; } = null!;
}