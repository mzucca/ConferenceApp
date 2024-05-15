using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class AppointmentCreate 
    { 
        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [Required]

        [JsonPropertyName("date")]
        public Object Date { get; set; }

        /// <summary>
        /// Gets or Sets Time
        /// </summary>
        [Required]

        [JsonPropertyName("time")]
        public Object Time { get; set; }

        /// <summary>
        /// Gets or Sets ClientId
        /// </summary>
        [Required]

        [JsonPropertyName("client_id")]
        public Object ClientId { get; set; }

        /// <summary>
        /// Gets or Sets DoctorId
        /// </summary>
        [Required]

        [JsonPropertyName("doctor_id")]
        public Object DoctorId { get; set; }
    }
}
