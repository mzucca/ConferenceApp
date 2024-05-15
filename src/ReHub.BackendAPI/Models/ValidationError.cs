using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ValidationError
    { 
        /// <summary>
        /// Gets or Sets Loc
        /// </summary>
        [Required]

        [JsonPropertyName("loc")]
        public string Loc { get; set; }

        /// <summary>
        /// Gets or Sets Msg
        /// </summary>
        [Required]

        [JsonPropertyName("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Required]

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
