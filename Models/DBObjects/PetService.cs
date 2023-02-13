using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RB_PetHotel.Models.DBObjects
{
    public partial class PetService
    {
        public Guid? PetId { get; set; }
        public Guid? ServiceId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }

        public virtual Pet? Pet { get; set; }
        public virtual Service? Service { get; set; }
    }
}
