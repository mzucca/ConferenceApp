using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ExternalRegisterDto
    {
        [Required]
        public string TokenId { get; set; }

        [Required]
        public string Provider { get; set; }

    }
}
