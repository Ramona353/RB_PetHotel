using System.ComponentModel.DataAnnotations;

namespace RB_PetHotel.Models
{
    public class UserModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid UserId { get; set; }
        [StringLength(100, ErrorMessage = "String too long (max. 100 chars)")]
        public string Username { get; set; } = null!;
        [StringLength(100, ErrorMessage = "String too long (max. 100 chars)")]
        public string Email { get; set; } = null!;
        [StringLength(100, ErrorMessage = "String too long (max. 100 chars)")]
        public string Password { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }
    }
}
