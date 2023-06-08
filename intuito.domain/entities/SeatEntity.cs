using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace intuito.domain.entities
{
    public class SeatEntity : BaseEntity
    {
        [Required]
        public short Number { get; set; }

        [Required]
        public short RowNumber { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }

        public RoomEntity? Room { get; set; }
    }
}
