using RB_PetHotel.Models.DBObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RB_PetHotel.Models
{
    public class PetServiceModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [ForeignKey("Pet")]
        public Guid? PetId { get; set; }
        [ForeignKey("Service")]
        public Guid? ServiceId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }

        public virtual Pet? Pet { get; set; }
        public virtual Service? Service { get; set; }
    }
}
