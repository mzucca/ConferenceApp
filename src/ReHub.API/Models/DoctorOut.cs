//using System.Text.Json.Serialization;
//using System.ComponentModel.DataAnnotations;
//using System.Runtime.Serialization;
//using ReHub.DbDataModel.Models;

//namespace ReHub.BackendAPI.Models
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [DataContract]
//    public partial class DoctorOut
//    { 
//        /// <summary>
//        /// Gets or Sets Email
//        /// </summary>
//        [Required]

//        [JsonPropertyName("email")]
//        public Object Email { get; set; }

//        /// <summary>
//        /// Gets or Sets Name
//        /// </summary>
//        [Required]

//        [JsonPropertyName("name")]
//        public Object Name { get; set; }

//        /// <summary>
//        /// Gets or Sets Surname
//        /// </summary>
//        [Required]

//        [JsonPropertyName("surname")]
//        public Object Surname { get; set; }

//        /// <summary>
//        /// Gets or Sets Gender
//        /// </summary>
//        [Required]

//        [JsonPropertyName("gender")]
//        public GenderType Gender { get; set; }

//        /// <summary>
//        /// Gets or Sets AvatarUrl
//        /// </summary>

//        [JsonPropertyName("avatar_url")]
//        public Object AvatarUrl { get; set; }

//        /// <summary>
//        /// Gets or Sets Type
//        /// </summary>
//        [Required]

//        [JsonPropertyName("type")]
//        public UserType Type { get; set; }

//        /// <summary>
//        /// Gets or Sets IsVerified
//        /// </summary>
//        [Required]

//        [JsonPropertyName("is_verified")]
//        public Object IsVerified { get; set; }

//        /// <summary>
//        /// Gets or Sets Id
//        /// </summary>
//        [Required]

//        [JsonPropertyName("id")]
//        public Object Id { get; set; }

//        /// <summary>
//        /// Gets or Sets SubType
//        /// </summary>
//        [Required]

//        [JsonPropertyName("sub_type")]
//        public UserSubType SubType { get; set; }

//        /// <summary>
//        /// Gets or Sets About
//        /// </summary>

//        [JsonPropertyName("about")]
//        public Object About { get; set; }

//    }
//}
