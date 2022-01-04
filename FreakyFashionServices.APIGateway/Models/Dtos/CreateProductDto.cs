﻿namespace FreakyFashionServices.APIGateway.Models.Dtos
{
    public class CreateProductDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string ArticleNumber { get; set; }

        public int StockLevel { get; set; }
    }
}
