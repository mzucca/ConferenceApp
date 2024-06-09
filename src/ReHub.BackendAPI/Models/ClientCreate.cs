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
    public partial class ClientCreate
    { 
        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [Required]

        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]

        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Surname
        /// </summary>
        [Required]

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or Sets Gender
        /// </summary>
        [Required]

        [JsonPropertyName("gender")]
        public GenderType Gender { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [Required]

        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets Password2
        /// </summary>
        [Required]

        [JsonPropertyName("password2")]
        public string Password2 { get; set; }

        /// <summary>
        /// Gets or Sets Rc
        /// </summary>
        //TODO what is RC ????
        [JsonPropertyName("rc")]
        public string Rc { get; set; }
    }
}
