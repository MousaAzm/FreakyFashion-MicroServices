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
                    StockLevel = createProductDto.StockLevel
                };
                _repository.UpdateStock(stock.ArticleNumber, stock);
                return Created("", result);
            }
            else
            {
                var result = await _repository.UpdateProduct(createProductDto.ArticleNumber, createProductDto);
                var stock = new StockDto
                {
                    ArticleNumber = createProductDto.ArticleNumber,
                    StockLevel = createProductDto.StockLevel
                };
                _repository.UpdateStock(stock.ArticleNumber, stock);
                return Created("", result);
            }

        }

        [HttpGet("basket/{articleNumber}")]
        public async Task<ActionResult> GetBasket(string articleNumber)
        {
            return Ok(await _repository.GetBasket(articleNumber));
        }

        [HttpPut("basket/{articleNumber}")]
        public async Task<ActionResult> CreateBasket(string articleNumber, CreateCartDto createCartDto)
        {
            await _repository.CreateBasket(articleNumber, createCartDto);
            return NoContent();
        }

        [HttpGet("order")]
        public async Task<ActionResult> GetOrders()
        {
            return Ok(await _repository.GetOrder());
        }

        [HttpPost("order")]
        public async Task<ActionResult<ReadOrderDto>> CreateOrder(CreateOrderDto createOrderDto)
        {
            var basket = await _repository.GetBasket(createOrderDto.Identifier);
            if (basket == null) return NotFound();
            var order = new CreateOrderDto()
            {
                Identifier = basket.Identifier!,
                Customer = createOrderDto.Customer,
                Date = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")
            };

            var getOrder = await _repository.CreateOrder(order);
            return Created("", getOrder.Id);
        }

        [HttpPut("order/{identifier}")]
        public async Task<ActionResult<ReadOrderDto>> UpdateOrder(string identifier, CreateOrderDto createOrderDto)
        {
            return Ok(await _repository.UpdateOrder(identifier, createOrderDto));
        }

        [HttpDelete("order/{identifier}")]
        public IActionResult RemoveOrder(string identifier)
        {
            _repository.DeleteOrder(identifier);
            return NoContent();
        }

    }
}
