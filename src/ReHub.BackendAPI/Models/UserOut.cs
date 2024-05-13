/*
 * Ri-Hub API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 0.9.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ReHub.DbDataModel.Models;

namespace BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class UserOut : IEquatable<UserOut>
    { 
        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [Required]

        [DataMember(Name="email")]
        public Object Email { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]

        [DataMember(Name="name")]
        public Object Name { get; set; }

        /// <summary>
        /// Gets or Sets Surname
        /// </summary>
        [Required]

        [DataMember(Name="surname")]
        public Object Surname { get; set; }

        /// <summary>
        /// Gets or Sets Gender
        /// </summary>
        [Required]

        [DataMember(Name="gender")]
        public GenderType Gender { get; set; }

        /// <summary>
        /// Gets or Sets AvatarUrl
        /// </summary>

        [DataMember(Name="avatar_url")]
        public Object AvatarUrl { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Required]

        [DataMember(Name="type")]
        public UserType Type { get; set; }

        /// <summary>
        /// Gets or Sets IsVerified
        /// </summary>
        [Required]

        [DataMember(Name="is_verified")]
        public Object IsVerified { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]

        [DataMember(Name="id")]
        public Object Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserOut {\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Surname: ").Append(Surname).Append("\n");
            sb.Append("  Gender: ").Append(Gender).Append("\n");
            sb.Append("  AvatarUrl: ").Append(AvatarUrl).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  IsVerified: ").Append(IsVerified).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((UserOut)obj);
        }

        /// <summary>
        /// Returns true if UserOut instances are equal
        /// </summary>
        /// <param name="other">Instance of UserOut to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserOut other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Surname == other.Surname ||
                    Surname != null &&
                    Surname.Equals(other.Surname)
                ) && 
                (
                    Gender == other.Gender ||
                    Gender != null &&
                    Gender.Equals(other.Gender)
                ) && 
                (
                    AvatarUrl == other.AvatarUrl ||
                    AvatarUrl != null &&
                    AvatarUrl.Equals(other.AvatarUrl)
                ) && 
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
                ) && 
                (
                    IsVerified == other.IsVerified ||
                    IsVerified != null &&
                    IsVerified.Equals(other.IsVerified)
                ) && 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Surname != null)
                    hashCode = hashCode * 59 + Surname.GetHashCode();
                    if (Gender != null)
                    hashCode = hashCode * 59 + Gender.GetHashCode();
                    if (AvatarUrl != null)
                    hashCode = hashCode * 59 + AvatarUrl.GetHashCode();
                    if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                    if (IsVerified != null)
                    hashCode = hashCode * 59 + IsVerified.GetHashCode();
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UserOut left, UserOut right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserOut left, UserOut right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
