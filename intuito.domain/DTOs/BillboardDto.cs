using intuito.domain.entities;
using intuito.domain.enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace intuito.domain.DTOs
{
    public class BillboardDto : BaseDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int RoomId { get; set; }
     }
}
