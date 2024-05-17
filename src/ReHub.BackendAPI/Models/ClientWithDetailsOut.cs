using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ReHub.DbDataModel.Models;

namespace BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ClientWithDetailsOut
    { 
        public ClientWithDetailsOut() { }
        public ClientWithDetailsOut(Client client)
        {
            Email = client.Email;
            Name = client.Name;
            Surname = client.Surname;
            Gender = client.Gender;
            AvatarUrl = client.AvatarUrl;
            Type = client.Type;
            IsVerified = client.IsVerified;
            Id = client.Id;
            SubType = client.SubType;
            Balance = client.Balance;
        }
        public void AddDetails(ClientDetails clientDetails)
        {

        }
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
        /// Gets or Sets AvatarUrl
        /// </summary>
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Required]
        [JsonPropertyName("type")]
        public UserType Type { get; set; }

        /// <summary>
        /// Gets or Sets IsVerified
        /// </summary>
        [Required]
        [JsonPropertyName("is_verified")]
        public bool IsVerified { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets SubType
        /// </summary>
        [Required]
        [JsonPropertyName("sub_type")]
        public UserSubType SubType { get; set; }

        /// <summary>
        /// Gets or Sets Balance
        /// </summary>
        [Required]

        [JsonPropertyName("balance")]
        public int Balance { get; set; }
        /// <summary>
        /// Gets or Sets Doctor
        /// </summary>

        [JsonPropertyName("doctor")]
        public DoctorOut Doctor { get; set; }

        /// <summary>
        /// Gets or Sets Details
        /// </summary>
        [Required]

        [JsonPropertyName("details")]
        public ClientDetails Details { get; set; }
    }
}
