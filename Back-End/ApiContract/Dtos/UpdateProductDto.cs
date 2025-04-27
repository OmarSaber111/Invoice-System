﻿namespace ApiContract.Dtos
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int SellerId { get; set; }
    }
}
