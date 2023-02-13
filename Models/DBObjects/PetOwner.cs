using System;
using System.Collections.Generic;

namespace RB_PetHotel.Models.DBObjects
{
    public partial class PetOwner
    {
        public Guid? PetId { get; set; }
        public Guid? OwnerId { get; set; }

        public virtual Owner? Owner { get; set; }
        public virtual Pet? Pet { get; set; }
    }
}
