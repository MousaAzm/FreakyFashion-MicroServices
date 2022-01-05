﻿using FreakyFashionServices.APIGateway.Models.Dtos;

namespace FreakyFashionServices.APIGateway.Services
{
    public interface IRepository
    {
        Task<IEnumerable<ReadProductDto>> GetProdcut();
        Task<ProductDto> CreateProduct(CreateProductDto createProductDto);
        Task<ProductDto> UpdateProduct(string articleNumber, CreateProductDto createProductDto);
        Task<IEnumerable<StockDto>> GetStock();
        void UpdateStock(string articleNumber, StockDto stockDto);
        Task<ReadCartDto> GetBasket(string articleNumber);
        Task<ReadCartDto> CreateBasket(string articleNumber, CreateCartDto createShoppingCartDto);
        Task<ReadOrderDto> CreateOrder(CreateOrderDto createOrderDto);
    }
}
