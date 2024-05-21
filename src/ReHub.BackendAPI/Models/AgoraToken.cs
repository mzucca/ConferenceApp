using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class AgoraToken
    { 
        /// <summary>
        /// Gets or Sets ChannelToken
        /// </summary>
        [Required]

        [JsonPropertyName("channel_token")]
        public Object ChannelToken { get; set; }

        /// <summary>
        /// Gets or Sets CommandToken
        /// </summary>
        [Required]

        [JsonPropertyName("command_token")]
        public Object CommandToken { get; set; }

        /// <summary>
        /// Gets or Sets Uid
        /// </summary>
        [Required]

        [JsonPropertyName("uid")]
        public Object Uid { get; set; }
    }
}
