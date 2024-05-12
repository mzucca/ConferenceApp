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
          /// An enumeration.
          /// </summary>
          /// <value>An enumeration.</value>
          [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
          public enum UserSubType
          {
              /// <summary>
              /// Enum AnamnesisEnum for anamnesis
              /// </summary>
              [EnumMember(Value = "anamnesis")]
              AnamnesisEnum = 0,
              /// <summary>
              /// Enum PhysioEnum for physio
              /// </summary>
              [EnumMember(Value = "physio")]
              PhysioEnum = 1          }
}
