using FreakyFashionServices.OrderService.Models.DbModel;

namespace FreakyFashionServices.OrderService.Models.Dtos
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }

        public string? Identifier { get; set; }

        public string? Customer { get; set; }

        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public string? Date { get; set; }
    }
}
