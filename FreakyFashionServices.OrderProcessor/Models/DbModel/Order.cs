using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreakyFashionServices.OrderProcessor.Models.DbModel
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public string? Identifier { get; set; }

        public string? Customer { get; set; }

        [ForeignKey("OrderCart")]
        public int OrderCartId { get; set; }

        public OrderCart OrderCarts { get; set; } = new OrderCart();

        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public string? Date { get; set; }
    }
}
