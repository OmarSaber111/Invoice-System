namespace ApiContract.Dtos
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int SellerId { get; set; }
    }
}
