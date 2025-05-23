﻿namespace ApiContract.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public int SellerId { get; set; }
        public string? SellerName { get; set; }
    }
}
