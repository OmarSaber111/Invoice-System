namespace Models.Entities
{
    public class Buyer
    {
        public int BuyerId { get; set; }
        public string? HashedPassword { get; set; }
        public string? UserName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }

        public User? User { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
    }

}
