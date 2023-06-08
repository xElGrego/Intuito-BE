using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
 
namespace intuito.domain.DTOs
{
    public class BaseDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]

        public int Id { get; set; }

        [JsonIgnore]
        public bool Status { get; set; } = true;
    }
}
