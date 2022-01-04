using FreakyFashionServices.BasketService.Models.DbModel;

namespace FreakyFashionServices.BasketService.Models.Dtos
{
    public class CreateShoppingCartDto
    {
        public string? Identifier { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();


    }
}
