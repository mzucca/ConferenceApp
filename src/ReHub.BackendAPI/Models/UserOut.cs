//using System.Text;
//using System.ComponentModel.DataAnnotations;
//using System.Runtime.Serialization;
//using ReHub.DbDataModel.Models;
//using System.Text.Json.Serialization;

//namespace ReHub.BackendAPI.Models
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [DataContract]
//    public partial class UserOut
//    { 
//        public UserOut() { }
//        internal UserOut(User user) 
//        {
//            Email = user.Email;
//            Name = user.Name;
//            Surname = user.Surname;
//            Gender = user.Gender;
//            AvatarUrl = user.Image;
//            Type = user.Type;
//            IsVerified = user.IsVerified;
//            Id = user.Id;
//        }
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
//        public string Name { get; set; }

//        /// <summary>
//        /// Gets or Sets Surname
//        /// </summary>
//        [Required]
//        [JsonPropertyName("surname")]
//        public string Surname { get; set; }

//        /// <summary>
//        /// Gets or Sets Gender
//        /// </summary>
//        [Required]
//        [JsonPropertyName("gender")]
//        public GenderType? Gender { get; set; }

//        /// <summary>
//        /// Gets or Sets AvatarUrl
//        /// </summary>
//        [JsonPropertyName("avatar_url")]
//        public string? AvatarUrl { get; set; }

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
//        public bool IsVerified { get; set; }
//        /// <summary>
//        /// Gets or Sets Id
//        /// </summary>
//        [Required]

//        [JsonPropertyName("id")]
//        public int Id { get; set; }
//    }
//}
