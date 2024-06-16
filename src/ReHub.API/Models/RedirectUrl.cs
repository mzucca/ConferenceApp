using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class RedirectUrl
    { 
        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [Required]

        [JsonPropertyName("url")]
        public Object Url { get; set; }
    }
}
