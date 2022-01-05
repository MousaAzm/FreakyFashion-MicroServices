using AutoMapper;
using FreakyFashionServices.OrderService.Models.DbModel;
using FreakyFashionServices.OrderService.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);
            var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "order", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(createOrderDto));

            channel.BasicPublish(
              exchange: "",
              routingKey: "order",
              basicProperties: null,
              body: body);
            
            return Ok(order);
        }

    
    }
}
