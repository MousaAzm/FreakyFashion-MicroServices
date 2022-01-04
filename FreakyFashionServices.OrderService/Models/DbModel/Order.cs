using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderService.Models.DbModel
{
    public class Order
    {
        public int Id { get; set; }

        public string? Identifier { get; set; }

        public string? Customer { get; set; }

        public string? Date { get; set; }
    }
}
