using RB_PetHotel.Models.DBObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RB_PetHotel.Models
{
    public class PetOwnerModel
    {
        [Key]
        public Guid? PetId { get; set; }
    
        [ForeignKey("Owner")]
        public Guid? OwnerId { get; set; }

        [Required]
        public virtual Owner? Owner { get; set; }
        [Required]
        public virtual Pet? Pet { get; set; }

    }
}
