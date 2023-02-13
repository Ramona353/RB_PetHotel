using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RB_PetHotel.Models.DBObjects
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }
    }
}
