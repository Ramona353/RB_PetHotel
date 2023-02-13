using System.ComponentModel.DataAnnotations;

namespace RB_PetHotel.Models
{
    public class ServiceModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid ServiceId { get; set; }
        [StringLength(100, ErrorMessage = "String too long (max. 100 chars)")]
        public string? ServiceName { get; set; }
        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars)")]
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
