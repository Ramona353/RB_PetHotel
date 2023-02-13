using System.ComponentModel.DataAnnotations;

namespace RB_PetHotel.Models
{
    public class PetModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid PetId { get; set; }

        [StringLength(100, ErrorMessage = "String too long (max. 100 chars)")]
        public string? PetName { get; set; }
        
        [StringLength(50, ErrorMessage = "String too long (max. 50 chars)")]
        public string? Breed { get; set; }
        
        public int? Age { get; set; }
        public decimal? Weight { get; set; }
        [StringLength(1000, ErrorMessage = "String too long (max. 1000 chars)")]
        public string? SpecialNeeds { get; set; }
    }
}
