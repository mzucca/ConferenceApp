using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ConferenceActionIn
    { 
        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [Required]

        [JsonPropertyName("action")]
        public Object Action { get; set; }

        /// <summary>
        /// Gets or Sets ConferenceId
        /// </summary>
        [Required]

        [JsonPropertyName("conference_id")]
        public Object ConferenceId { get; set; }

        /// <summary>
        /// Gets or Sets ActorId
        /// </summary>
        [Required]

        [JsonPropertyName("actor_id")]
        public Object ActorId { get; set; }
     }
}
