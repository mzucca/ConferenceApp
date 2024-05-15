using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class HTTPValidationError
    { 
        /// <summary>
        /// Gets or Sets Detail
        /// </summary>

        [JsonPropertyName("detail")]
        public Object Detail { get; set; }

    }
}
