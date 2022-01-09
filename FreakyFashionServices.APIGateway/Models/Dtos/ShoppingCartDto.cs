namespace FreakyFashionServices.APIGateway.Models.Dtos
{
    public class ShoppingCartDto
    {
        public string? Identifier { get; set; }

        public List<CartItemsDto> Items { get; set; } = new List<CartItemsDto>();

    }
}
