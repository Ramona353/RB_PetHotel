using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RB_PetHotel.Models
{
    public class OwnerModel
    {

        [System.ComponentModel.DataAnnotations.Key]
        public Guid OwnerId { get; set; }

        [StringLength(100, ErrorMessage = "String too long (max. 100 chars)")]
        public string? OwnerName { get; set; }
        [StringLength(15, ErrorMessage = "String too long (max. 15 chars)")]
        public string? Phone { get; set; }
        [StringLength(150, ErrorMessage = "String too long (max. 150 chars)")]
        public string? Email { get; set; }
    }
}
