using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? Name { get; set; }
        [Required, EmailAddress, MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "National ID must be exactly 14 digits.")]
        public string? NationalId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Seller? Seller { get; set; }
        public Buyer? Buyer { get; set; }
        public Admin? Admin { get; set; }
        public ICollection<GroupUser>? GroupUsers { get; set; }
    }
}

