 
using System.ComponentModel.DataAnnotations;
 
namespace intuito.domain.DTOs
{
    public class RoomDto : BaseDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public short Number { get; set; }
    }
}
