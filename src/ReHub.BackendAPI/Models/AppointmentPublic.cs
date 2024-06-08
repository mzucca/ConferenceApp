using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ReHub.DbDataModel.Models;
using ReHub.DbDataModel.Enums;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// Represents an Appointment 
    /// </summary>
    [DataContract]
    public partial class AppointmentPublic
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// A unique name for this session
        /// </summary>
        [JsonPropertyName("name")]
        [Required]
        public string Name {  get; set; }

        /// <summary>
        /// The district we'll treat in this session
        /// </summary>
        [JsonPropertyName("district")]
        public District District { get; set; }

        /// <summary>
        /// Gets or Sets Date in unix format
        /// </summary>
        [Required]
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or Sets IsParticipant
        /// </summary>
        [Required]
        [JsonPropertyName("is_participant")]
        public bool IsParticipant { get; set; }

        /// <summary>
        /// Gets or Sets ListenersNum
        /// </summary>
        [Required]
        [JsonPropertyName("listeners_num")]
        public int ListenersNum { get; set; }

        /// <summary>
        /// Gets or Sets MaxListeners
        /// </summary>
        [Required]
        [JsonPropertyName("max_listeners")]
        public int MaxListeners { get; set; }

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
