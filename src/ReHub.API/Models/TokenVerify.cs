using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class TokenVerify
    { 
        /// <summary>
        /// Gets or Sets IsValid
        /// </summary>

        [JsonPropertyName("is_valid")]
        public bool IsValid { get; set; }

    }
}
