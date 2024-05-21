using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PaymentDataIn
    { 
        /// <summary>
        /// Gets or Sets LessonPackageId
        /// </summary>
        [Required]

        [JsonPropertyName("lesson_package_id")]
        public Object LessonPackageId { get; set; }

        /// <summary>
        /// Gets or Sets DiscountCouponName
        /// </summary>

        [JsonPropertyName("discount_coupon_name")]
        public Object DiscountCouponName { get; set; }

        /// <summary>
        /// Gets or Sets PaymentProcessor
        /// </summary>

        [JsonPropertyName("payment_processor")]
        public PaymentProcessorType PaymentProcessor { get; set; }
    }
}
