using AutoMapper;
using FreakyFashionServices.CatalogService.Data;
using FreakyFashionServices.CatalogService.Helper;
using FreakyFashionServices.CatalogService.Models.DbModel;
using FreakyFashionServices.CatalogService.Models.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace FreakyFashionServices.CatalogService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CatalogDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(CatalogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(_mapper.Map<IEnumerable<ReadProductDto>>(products));
        }

        [HttpGet("{articleNumber}")]
        public IActionResult GetProductById(string articleNumber)
        {
            var getProduct = _context.Products.FirstOrDefault(p => p.ArticleNumber == articleNumber);
            if (getProduct == null) return NotFound();

            return Ok(_mapper.Map<ReadProductDto>(getProduct));
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto createProductDto)
        {        
            var product = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }
      
        [HttpPut("{articleNumber}")]
        public IActionResult UpdateProduct(string articleNumber, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var getProduct = _context.Products.FirstOrDefault(x => x.ArticleNumber == articleNumber);
            if (getProduct == null) return NotFound();

            var product = _mapper.Map(updateProductDto, getProduct);
            _context.Products.Update(getProduct);
            _context.SaveChanges();

            return Ok(product);
        }

       
    }
}
