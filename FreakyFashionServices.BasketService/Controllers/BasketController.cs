using AutoMapper;
using FreakyFashionServices.BasketService.Models.DbModel;
using FreakyFashionServices.BasketService.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace FreakyFashionServices.BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IDistributedCache _redisCashe;
        private readonly IMapper _mapper;
        public BasketController(IDistributedCache redisCashe, IMapper mapper)
        {
            _redisCashe = redisCashe;
            _mapper = mapper;
        }

        [HttpGet("{identifier}")]
        public ActionResult<ShoppingCartDto> GetBasket(string identifier)
        {
            var basket = _redisCashe.GetString(identifier);
            if (basket == null) return NotFound();
            return Ok(basket);
        }

        [HttpPut("{identifier}")]
        public IActionResult CreateBasket(string identifier, ShoppingCartDto createShoppingCartDto)
        {
            var basket = _mapper.Map<ShoppingCart>(createShoppingCartDto);
            var serialize = JsonSerializer.Serialize(basket);
            _redisCashe.SetString(identifier, serialize);
            return NoContent();
        }

    }
}
