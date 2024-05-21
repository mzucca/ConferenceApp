using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PaymentDataOut
    { 
        /// <summary>
        /// Gets or Sets LessonPackageName
        /// </summary>
        [Required]

        [JsonPropertyName("lesson_package_name")]
        public Object LessonPackageName { get; set; }

        /// <summary>
        /// Gets or Sets Cost
        /// </summary>
        [Required]

        [JsonPropertyName("cost")]
        public Object Cost { get; set; }

        /// <summary>
        /// Gets or Sets LessonsNum
        /// </summary>
        [Required]

        [JsonPropertyName("lessons_num")]
        public Object LessonsNum { get; set; }

        /// <summary>
        /// Gets or Sets Discount
        /// </summary>
        [Required]

        [JsonPropertyName("discount")]
        public Object Discount { get; set; }
    }
}
