using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class UserEditPassword
    { 
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
        /// Gets or Sets OldPassword
        /// </summary>
        [Required]

        [JsonPropertyName("old_password")]
        public string OldPassword { get; set; }

    }
}
