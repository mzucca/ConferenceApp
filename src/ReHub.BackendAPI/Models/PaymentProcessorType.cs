using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{

    /// <summary>
    /// An enumeration.
    /// </summary>
    /// <value>An enumeration.</value>
    public enum PaymentProcessorType
          {
              /// <summary>
              /// Enum StripeEnum for stripe
              /// </summary>
              [EnumMember(Value = "stripe")]
              StripeEnum = 0          }
}
