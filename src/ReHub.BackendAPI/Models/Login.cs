using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BackendAPI.Models
{
    public partial class Login
    { 
        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [Required]
        [DataMember(Name="email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
