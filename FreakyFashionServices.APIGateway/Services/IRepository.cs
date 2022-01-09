using FreakyFashionServices.APIGateway.Models.Dtos;

namespace FreakyFashionServices.APIGateway.Services
{
    public interface IRepository
    {
        Task<IEnumerable<ReadProductDto>> GetProdcut();
        Task<ProductDto> CreateProduct(CreateProductDto createProductDto);
        Task<ProductDto> UpdateProduct(string articleNumber, CreateProductDto createProductDto);
        Task<IEnumerable<StockDto>> GetStock();
        Task<StockDto> GetStockByArticleNummber(string articleNumber);
        void UpdateStock(string articleNumber, StockDto stockDto);
        Task<ShoppingCartDto> GetBasket(string articleNumber);
        Task<ShoppingCartDto> CreateBasket(string articleNumber, ShoppingCartDto shoppingCartDto);
        Task<OrderDto> CreateOrder(OrderDto orderDto);
    }
}
