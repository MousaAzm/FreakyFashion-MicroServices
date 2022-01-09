using FreakyFashionServices.OrderProcessor.Models.DbModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreakyFashionServices.OrderProcessor.Models.Dtos
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }

        public string? Identifier { get; set; }

        public string? Customer { get; set; }

        public OrderCart OrderCarts { get; set; } = new OrderCart();

        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public string? Date { get; set; }
    }
}
