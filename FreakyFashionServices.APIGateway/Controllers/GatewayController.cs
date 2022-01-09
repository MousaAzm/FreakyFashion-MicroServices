using FreakyFashionServices.APIGateway.Models.Dtos;
using FreakyFashionServices.APIGateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.APIGateway.Controllers
{
    [Route("api")]
    [ApiController]
    public class GatewayController : ControllerBase
    {

        private readonly IRepository _repository;

        public GatewayController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("product")]
        public async Task<IActionResult> GetAllProdcuts()
        {
            return Ok(await _repository.GetProdcut());
        }

        [HttpPost("product")]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            var product = await _repository.GetProdcut();
            var getArticleNumber = product.FirstOrDefault(m => m.ArticleNumber == createProductDto.ArticleNumber);
            if (getArticleNumber == null)
            {
                var result = await _repository.CreateProduct(createProductDto);
                var stock = new StockDto
                {
                    ArticleNumber = createProductDto.ArticleNumber,
                    StockLevel = 1
                };
                _repository.UpdateStock(stock.ArticleNumber, stock);
                return Created("", result);
            }
            else
            {
                var result = await _repository.UpdateProduct(createProductDto.ArticleNumber, createProductDto);
                var getStock = await _repository.GetStockByArticleNummber(createProductDto.ArticleNumber);            
                getStock.StockLevel += 1;               
                _repository.UpdateStock(createProductDto.ArticleNumber, getStock);
                return Created("", result);
            }

        }

        [HttpGet("basket/{articleNumber}")]
        public async Task<ActionResult> GetBasket(string articleNumber)
        {
            return Ok(await _repository.GetBasket(articleNumber));
        }

        [HttpPut("basket/{articleNumber}")]
        public async Task<ActionResult> CreateBasket(string articleNumber, ShoppingCartDto createCartDto)
        {
            await _repository.CreateBasket(articleNumber, createCartDto);
            return NoContent();
        }

        [HttpPost("order")]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto)
        {
            var basket = await _repository.GetBasket(orderDto.Identifier);      
            if (basket == null) return NotFound();

            var order = new OrderDto()
            {
                Identifier = basket.Identifier!,
                Customer = orderDto.Customer,
                Date = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
                OrderLines = basket.Items.Select(m => new CartItemsDto()
                {
                    ProductId = m.ProductId,
                    Quantity = m.Quantity,
                }).ToList(),
            };
 
            var getOrder = await _repository.CreateOrder(order);
            return Created("", getOrder.OrderId);
        }


    }
}
