using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Token
    { 
        /// <summary>
        /// Gets or Sets AccessToken
        /// </summary>
        [Required]

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or Sets TokenType
        /// </summary>
        [Required]

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

    }
}
