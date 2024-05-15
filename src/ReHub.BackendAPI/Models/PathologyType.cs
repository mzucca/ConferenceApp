using System.Runtime.Serialization;

namespace BackendAPI.Models
{

    /// <summary>
    /// An enumeration.
    /// </summary>
    /// <value>An enumeration.</value>
    public enum PathologyType
          {
              /// <summary>
              /// Enum NUMBER_1 for pathology_1
              /// </summary>
              [EnumMember(Value = "pathology_1")]
              NUMBER_1 = 0,
              /// <summary>
              /// Enum NUMBER_2 for pathology_2
              /// </summary>
              [EnumMember(Value = "pathology_2")]
              NUMBER_2 = 1,
              /// <summary>
              /// Enum NUMBER_3 for pathology_3
              /// </summary>
              [EnumMember(Value = "pathology_3")]
              NUMBER_3 = 2,
              /// <summary>
              /// Enum NUMBER_4 for pathology_4
              /// </summary>
              [EnumMember(Value = "pathology_4")]
              NUMBER_4 = 3,
              /// <summary>
              /// Enum NUMBER_5 for pathology_5
              /// </summary>
              [EnumMember(Value = "pathology_5")]
              NUMBER_5 = 4,
              /// <summary>
              /// Enum NUMBER_6 for pathology_6
              /// </summary>
              [EnumMember(Value = "pathology_6")]
              NUMBER_6 = 5          }
}
