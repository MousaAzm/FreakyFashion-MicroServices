namespace FreakyFashionServices.APIGateway.Models.Dtos
{
    public class ReadCartDto
    {
        public string? Identifier { get; set; }

        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();

    }
}
