namespace Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public int SellerId { get; set; }
        public Seller? Seller { get; set; }

        public ICollection<Invoice>? Invoices { get; set; }
    }

}
