using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace intuito.domain.entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]

        public int Id { get; set; }

        [JsonIgnore]
        [Required]
        public bool Status { get; set; } = true;
    }
}
