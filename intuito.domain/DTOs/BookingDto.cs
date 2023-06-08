using intuito.domain.entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace intuito.domain.DTOs
{
    public class BookingDto : BaseDto
    {
        [Required]
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
 
        public int SeatId { get; set; }
 
        public int BillboardId { get; set; }
     }
}
