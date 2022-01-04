using FreakyFashionServices.BasketService.Models.DbModel;

namespace FreakyFashionServices.BasketService.Models.Dtos
{
    public class ReadShoppingCartDto
    {
        public string? Identifier { get; set; }

        public decimal TotalPrice { get;}

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}
