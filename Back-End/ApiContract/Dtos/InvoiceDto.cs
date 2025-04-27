namespace ApiContract.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public bool Payment { get; set; }
    }

}
