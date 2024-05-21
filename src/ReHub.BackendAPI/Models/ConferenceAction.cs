using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ConferenceAction
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [JsonPropertyName("id")]
        public Object Id { get; set; }

        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [Required]

        [JsonPropertyName("action")]
        public Object Action { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [Required]

        [JsonPropertyName("created_at")]
        public Object CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [Required]

        [JsonPropertyName("updated_at")]
        public Object UpdatedAt { get; set; }

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
