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

namespace BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ValidationError : IEquatable<ValidationError>
    { 
        /// <summary>
        /// Gets or Sets Loc
        /// </summary>
        [Required]

        [DataMember(Name="loc")]
        public Object Loc { get; set; }

        /// <summary>
        /// Gets or Sets Msg
        /// </summary>
        [Required]

        [DataMember(Name="msg")]
        public Object Msg { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Required]

        [DataMember(Name="type")]
        public Object Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ValidationError {\n");
            sb.Append("  Loc: ").Append(Loc).Append("\n");
            sb.Append("  Msg: ").Append(Msg).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ValidationError)obj);
        }

        /// <summary>
        /// Returns true if ValidationError instances are equal
        /// </summary>
        /// <param name="other">Instance of ValidationError to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ValidationError other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Loc == other.Loc ||
                    Loc != null &&
                    Loc.Equals(other.Loc)
                ) && 
                (
                    Msg == other.Msg ||
                    Msg != null &&
                    Msg.Equals(other.Msg)
                ) && 
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
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
                    if (Loc != null)
                    hashCode = hashCode * 59 + Loc.GetHashCode();
                    if (Msg != null)
                    hashCode = hashCode * 59 + Msg.GetHashCode();
                    if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ValidationError left, ValidationError right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValidationError left, ValidationError right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
