namespace Models.Entities
{
    public class Seller
    {
        public int SellerId { get; set; }
        public int UserId { get; set; }
        public string? HashedPassword { get; set; }
        public string? UserName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? StoreName { get; set; }
        public string? TypeOFProduct { get; set; }
        public int GovernmentId { get; set; }

        public User? User { get; set; }
        public Government? Government { get; set; }

        public ICollection<Product>? Products { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
    }
}
