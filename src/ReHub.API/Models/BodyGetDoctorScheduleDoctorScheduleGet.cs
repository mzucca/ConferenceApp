using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class BodyGetDoctorScheduleDoctorScheduleGet
    { 
        /// <summary>
        /// Gets or Sets FromDate
        /// </summary>

        [JsonPropertyName("from_date")]
        public Object FromDate { get; set; }

        /// <summary>
        /// Gets or Sets ToDate
        /// </summary>

        [JsonPropertyName("to_date")]
        public Object ToDate { get; set; }
    }
}
