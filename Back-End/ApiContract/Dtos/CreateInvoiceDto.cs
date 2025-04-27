namespace ApiContract.Dtos
{
    public class CreateInvoiceDto
    {
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public bool Payment { get; set; }
    }

}
