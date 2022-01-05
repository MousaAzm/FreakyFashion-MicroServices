using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderProcessor.Models.DbModel
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public string? Identifier { get; set; }

        public string? Customer { get; set; }

        public string? Date { get; set; }
    }
}
