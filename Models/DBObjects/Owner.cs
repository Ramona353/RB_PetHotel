using System;
using System.Collections.Generic;

namespace RB_PetHotel.Models.DBObjects
{
    public partial class Owner
    {
        public Guid OwnerId { get; set; }
        public string? OwnerName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
