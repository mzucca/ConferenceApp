using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ReHub.DbDataModel.Models;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class AppointmentPublic
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]

        [JsonPropertyName("id")]
        public Object Id { get; set; }

        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [Required]

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or Sets Time
        /// </summary>
        [Required]

        [JsonPropertyName("time")]
        public Object Time { get; set; }


        /// <summary>
        /// Gets or Sets IsParticipant
        /// </summary>
        [Required]

        [JsonPropertyName("is_participant")]
        public Object IsParticipant { get; set; }

        /// <summary>
        /// Gets or Sets ListenersNum
        /// </summary>
        [Required]

        [JsonPropertyName("listeners_num")]
        public Object ListenersNum { get; set; }

        /// <summary>
        /// Gets or Sets MaxListeners
        /// </summary>
        [Required]

        [JsonPropertyName("max_listeners")]
        public Object MaxListeners { get; set; }

        /// <summary>
        /// Gets or Sets Speaker
        /// </summary>
        [Required]

        [JsonPropertyName("speaker")]
        public UserOut Speaker { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [Required]

        [JsonPropertyName("status")]
        public AppointmentStatusType Status { get; set; }

    }
}
