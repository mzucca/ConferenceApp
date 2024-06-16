using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReHub.BackendAPI.Models
{
    public partial class Login
    { 
        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
