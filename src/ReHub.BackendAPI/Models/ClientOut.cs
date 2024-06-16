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
//    public partial class ClientOut
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
//        /// Gets or Sets Balance
//        /// </summary>
//        [Required]

//        [JsonPropertyName("balance")]
//        public Object Balance { get; set; }

//        /// <summary>
//        /// Gets or Sets Doctor
//        /// </summary>

//        [JsonPropertyName("doctor")]
//        public DoctorOut Doctor { get; set; }

//        /// <summary>
//        /// Returns the string presentation of the object
//        /// </summary>
//        /// <returns>String presentation of the object</returns>
//        public override string ToString()
//        {
//            var sb = new StringBuilder();
//            sb.Append("class ClientOut {\n");
//            sb.Append("  Email: ").Append(Email).Append("\n");
//            sb.Append("  Name: ").Append(Name).Append("\n");
//            sb.Append("  Surname: ").Append(Surname).Append("\n");
//            sb.Append("  Gender: ").Append(Gender).Append("\n");
//            sb.Append("  AvatarUrl: ").Append(AvatarUrl).Append("\n");
//            sb.Append("  Type: ").Append(Type).Append("\n");
//            sb.Append("  IsVerified: ").Append(IsVerified).Append("\n");
//            sb.Append("  Id: ").Append(Id).Append("\n");
//            sb.Append("  SubType: ").Append(SubType).Append("\n");
//            sb.Append("  Balance: ").Append(Balance).Append("\n");
//            sb.Append("  Doctor: ").Append(Doctor).Append("\n");
//            sb.Append("}\n");
//            return sb.ToString();
//        }
//    }
//}
