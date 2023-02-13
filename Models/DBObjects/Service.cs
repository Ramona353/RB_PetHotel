using System;
using System.Collections.Generic;

namespace RB_PetHotel.Models.DBObjects
{
    public partial class Service
    {
        public Guid ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
