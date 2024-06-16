using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ConferenceIn
    { 
        /// <summary>
        /// Gets or Sets ChannelName
        /// </summary>
        [Required]

        [JsonPropertyName("channel_name")]
        public Object ChannelName { get; set; }

        /// <summary>
        /// Gets or Sets ParticipantIds
        /// </summary>
        [Required]

        [JsonPropertyName("participant_ids")]
        public Object ParticipantIds { get; set; }

    }
}
