using intuito.domain.enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace intuito.domain.DTOs
{
    public class MovieDto : BaseDto
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MovieGenreEnum Genre { get; set; }

        [Required]
        public short AllowedAge { get; set; }

        [Required]
        public short LengthMinutes { get; set; }
    }
}
