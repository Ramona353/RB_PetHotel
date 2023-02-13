using RB_PetHotel.Models.DBObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RB_PetHotel.Models
{
    public class PetRoomModel
    {
        [Key]
        public Guid? PetId { get; set; }
        
        [ForeignKey("RoomId")]
        public Guid? RoomId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }

        [Required]
        public virtual Pet? Pet { get; set; }
        [Required]
        public virtual Room? Room { get; set; }
    }
}
