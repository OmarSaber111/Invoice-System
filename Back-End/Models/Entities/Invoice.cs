namespace Models.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public bool Payment { get; set; }
        public Seller? Seller { get; set; }
        public Buyer? Buyer { get; set; }
        public Product? Product { get; set; }
    }

}
