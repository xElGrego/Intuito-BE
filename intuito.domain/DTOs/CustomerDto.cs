

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace intuito.domain.DTOs
{
    public class CustomerDto : BaseDto
    {
        [Required]
        [MaxLength(20)]
        [JsonPropertyName("cedula")]
        public string DocumentNumber { get; set; }

        [Required]
        [MaxLength(30)]

        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Lastname { get; set; }

        [Required]
        public short Age { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }
}
