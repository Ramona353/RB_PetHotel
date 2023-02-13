using System;
using System.Collections.Generic;

namespace RB_PetHotel.Models.DBObjects
{
    public partial class Pet
    {
        public Guid PetId { get; set; }
        public string? PetName { get; set; }
        public string? Breed { get; set; }
        public int? Age { get; set; }
        public decimal? Weight { get; set; }
        public string? SpecialNeeds { get; set; }
    }
}
