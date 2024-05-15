using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class NotificationCreate
    { 
        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [Required]

        [JsonPropertyName("message")]
        public Object Message { get; set; }

        /// <summary>
        /// Gets or Sets RecipientTypes
        /// </summary>
        [Required]

        [JsonPropertyName("recipient_types")]
        public Object RecipientTypes { get; set; }

        /// <summary>
        /// Gets or Sets RecipientIds
        /// </summary>

        [JsonPropertyName("recipient_ids")]
        public Object RecipientIds { get; set; }
    }
}
