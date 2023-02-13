using System;
using System.Collections.Generic;

namespace RB_PetHotel.Models.DBObjects
{
    public partial class Room
    {
        public Guid RoomId { get; set; }
        public string? RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public int? Occupancy { get; set; }
        public decimal? Price { get; set; }
    }
}
