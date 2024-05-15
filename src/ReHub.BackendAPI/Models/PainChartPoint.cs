using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PainChartPoint
    { 
        /// <summary>
        /// Gets or Sets XScalePointName
        /// </summary>
        [Required]

        [JsonPropertyName("x_scale_point_name")]
        public Object XScalePointName { get; set; }

        /// <summary>
        /// Gets or Sets AvgPainRateBefore
        /// </summary>

        [JsonPropertyName("avg_pain_rate_before")]
        public Object AvgPainRateBefore { get; set; }

        /// <summary>
        /// Gets or Sets AvgPainRateAfter
        /// </summary>

        [JsonPropertyName("avg_pain_rate_after")]
        public Object AvgPainRateAfter { get; set; }
    }
}
