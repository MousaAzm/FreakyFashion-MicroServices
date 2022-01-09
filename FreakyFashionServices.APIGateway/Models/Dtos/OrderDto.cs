namespace FreakyFashionServices.APIGateway.Models.Dtos
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }

        public string Identifier { get; set; }

        public string? Customer { get; set; }

        public List<CartItemsDto> OrderLines { get; set; } = new List<CartItemsDto>();

        public string? Date { get; set; }
    }
}
