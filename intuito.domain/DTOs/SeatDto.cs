using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace intuito.domain.DTOs
{
    public class SeatDto : BaseDto
    {
        [Required]
        public short Number { get; set; }

        [Required]
        public short RowNumber { get; set; }

        [Required]
        public int RoomId { get; set; }
     }
}
