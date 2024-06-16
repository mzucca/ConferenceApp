using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ReferrerReportRequest
    { 
        /// <summary>
        /// Gets or Sets ReferrerIds
        /// </summary>
        [Required]

        [JsonPropertyName("referrer_ids")]
        public Object ReferrerIds { get; set; }

        /// <summary>
        /// Gets or Sets FromDate
        /// </summary>
        [Required]

        [JsonPropertyName("from_date")]
        public Object FromDate { get; set; }

        /// <summary>
        /// Gets or Sets ToDate
        /// </summary>
        [Required]

        [JsonPropertyName("to_date")]
        public Object ToDate { get; set; }
    }
}
