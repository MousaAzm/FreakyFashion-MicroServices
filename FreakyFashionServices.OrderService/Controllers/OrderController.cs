using AutoMapper;
using FreakyFashionServices.OrderService.Models.DbModel;
using FreakyFashionServices.OrderService.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace FreakyFashionServices.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        public OrderController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult GetOrders()
        //{
        //    var getOrder = _context.Orders.ToList();
        //    if(getOrder == null) return NotFound();
        //    return Ok(_mapper.Map<IEnumerable<ReadOrderDto>>(getOrder));
        //}

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
           return NoContent();  
          
        }

        //[HttpPut("{identifier}")]
        //public IActionResult UpdateOrder(string identifier, [FromBody] UpdateOrderDto updateOrderDto)
        //{
        //    var getOrder = _context.Orders.FirstOrDefault(o => o.Identifier == identifier);
        //    if (getOrder == null) return NotFound();

        //    _mapper.Map(updateOrderDto, getOrder);
        //    _context.Orders.Update(getOrder);
        //    _context.SaveChanges();

        //    return NoContent();
        //}

        //[HttpDelete("{identifier}")]
        //public IActionResult DeleteOrder(string identifier)
        //{
        //    var getOrder = _context.Orders.FirstOrDefault(o => o.Identifier == identifier);
        //    if(getOrder == null) return NotFound();

        //    _context.Orders.Remove(getOrder);
        //    _context.SaveChanges();

        //    return NoContent();
        //}
    }
}
