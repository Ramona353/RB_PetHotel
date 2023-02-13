using System.ComponentModel.DataAnnotations;

namespace RB_PetHotel.Models
{
    public class RoomModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid RoomId { get; set; }
        [StringLength(5, ErrorMessage = "String too long (max. 5 chars)")]
        public string? RoomNumber { get; set; }
        [StringLength(50, ErrorMessage = "String too long (max. 50 chars)")]
        public string? RoomType { get; set; }
        public int? Occupancy { get; set; }
        public decimal? Price { get; set; }
    }
}
