using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReHub.BackendAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class LessonPackage
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]

        [JsonPropertyName("id")]
        public Object Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]

        [JsonPropertyName("name")]
        public Object Name { get; set; }

        /// <summary>
        /// Gets or Sets LessonsNum
        /// </summary>
        [Required]

        [JsonPropertyName("lessons_num")]
        public Object LessonsNum { get; set; }

        /// <summary>
        /// Gets or Sets Cost
        /// </summary>
        [Required]

        [JsonPropertyName("cost")]
        public Object Cost { get; set; }

    }
}
