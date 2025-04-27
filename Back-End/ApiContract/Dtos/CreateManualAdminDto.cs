using System.ComponentModel.DataAnnotations;

namespace ApiContract.Dtos
{
    public class CreateManualAdminDto
    {
        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "National ID must be exactly 14 digits.")]
        public string? NationalId { get; set; }

        [Required, MaxLength(50)]
        public string? Username { get; set; }

        [Required, MinLength(6)]
        public string? Password { get; set; }
    }
}
