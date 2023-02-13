using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RB_PetHotel.Models.DBObjects
{
    public partial class PetRoom
    {
        public Guid? PetId { get; set; }
        public Guid? RoomId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }

        public virtual Pet? Pet { get; set; }
        public virtual Room? Room { get; set; }
    }
}
