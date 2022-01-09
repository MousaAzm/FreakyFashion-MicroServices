using AutoMapper;
using FreakyFashionServices.StockService.Data;
using FreakyFashionServices.StockService.Models.DbModel;
using FreakyFashionServices.StockService.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.StockService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly StockDbContext _context;
        private readonly IMapper _mapper;

        public StockController(StockDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllStocks()
        {
            var stocks = _context.Stocks.ToList();
            return Ok(_mapper.Map<IEnumerable<StockDto>>(stocks));
        }


        [HttpPut("{articleNumber}")]
        public IActionResult UpdateStock(string articleNumber, [FromBody] StockDto stockDto)
        {

            var stock = _context.Stocks.FirstOrDefault(m => m.ArticleNumber == articleNumber);
            if (stock == null)
            {
                var newStock = _mapper.Map<Stock>(stockDto);
                newStock.ArticleNumber = articleNumber;
                _context.Stocks.Add(newStock);
            }
            else
            {
                _context.Stocks.Remove(stock);
                _context.SaveChanges();
                _context.Stocks.Add(stock);
                stock.ArticleNumber = articleNumber;
                stock.StockLevel = stockDto.StockLevel;
            }

            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("{articleNumber}")]
        public IActionResult GetStockByArticleNummber(string articleNumber)
        {
            var stock = _context.Stocks.FirstOrDefault(s => s.ArticleNumber == articleNumber);
            if (stock == null) return NotFound();

            return Ok(_mapper.Map<StockDto>(stock));
        }

    }
}
