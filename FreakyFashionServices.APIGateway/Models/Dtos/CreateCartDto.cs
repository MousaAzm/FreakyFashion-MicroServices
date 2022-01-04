namespace FreakyFashionServices.APIGateway.Models.Dtos
{
    public class CreateCartDto
    {
        public string? Identifier { get; set; }

        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    }
}
