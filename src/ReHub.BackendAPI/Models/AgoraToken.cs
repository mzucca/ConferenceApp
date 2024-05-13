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
    public partial class AgoraToken : IEquatable<AgoraToken>
    { 
        /// <summary>
        /// Gets or Sets ChannelToken
        /// </summary>
        [Required]

        [DataMember(Name="channel_token")]
        public Object ChannelToken { get; set; }

        /// <summary>
        /// Gets or Sets CommandToken
        /// </summary>
        [Required]

        [DataMember(Name="command_token")]
        public Object CommandToken { get; set; }

        /// <summary>
        /// Gets or Sets Uid
        /// </summary>
        [Required]

        [DataMember(Name="uid")]
        public Object Uid { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AgoraToken {\n");
            sb.Append("  ChannelToken: ").Append(ChannelToken).Append("\n");
            sb.Append("  CommandToken: ").Append(CommandToken).Append("\n");
            sb.Append("  Uid: ").Append(Uid).Append("\n");
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
            return obj.GetType() == GetType() && Equals((AgoraToken)obj);
        }

        /// <summary>
        /// Returns true if AgoraToken instances are equal
        /// </summary>
        /// <param name="other">Instance of AgoraToken to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AgoraToken other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    ChannelToken == other.ChannelToken ||
                    ChannelToken != null &&
                    ChannelToken.Equals(other.ChannelToken)
                ) && 
                (
                    CommandToken == other.CommandToken ||
                    CommandToken != null &&
                    CommandToken.Equals(other.CommandToken)
                ) && 
                (
                    Uid == other.Uid ||
                    Uid != null &&
                    Uid.Equals(other.Uid)
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
                    if (ChannelToken != null)
                    hashCode = hashCode * 59 + ChannelToken.GetHashCode();
                    if (CommandToken != null)
                    hashCode = hashCode * 59 + CommandToken.GetHashCode();
                    if (Uid != null)
                    hashCode = hashCode * 59 + Uid.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(AgoraToken left, AgoraToken right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AgoraToken left, AgoraToken right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}